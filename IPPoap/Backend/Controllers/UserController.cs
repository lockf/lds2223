using Backend.Controllers.Services;
using Backend.Models;
using Backend.Models.VM;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Backend.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly EmailService _emailService;

        public UserController(UserService userService, EmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }

        /// <summary>
        /// Gets a list of Admins names
        /// </summary>
        /// <returns>A list of Managers names</returns>
        [HttpGet("getAdmins")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "List of Admins names", Description = "Lists of Admins names in DB")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetAdmins()
        {
            bool existsA = _userService.AdminExists();
            if (existsA)
            {
                List<string> list = await _userService.GetAdminsList();
                return Ok(list);
            }
            return NotFound();
        }

        /// <summary>
        /// Gets the Admin info
        /// </summary>
        /// <returns>A Admin information</returns>
        [HttpGet("{adminId}/getAdminInfo")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "Admin info", Description = "Return info about the Admin")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetAdminInfo(int adminId)
        {
            bool existsA = _userService.AdminExists();
            if (existsA)
            {
                AdminVM adm = await _userService.AdminInfo(adminId);
                return Ok(adm);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates Admin, and sends email with the credentials.
        /// </summary>
        /// <param name="user"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo (Admin)
        ///     {
        ///        "userName": "admin",
        ///        "Email": "admin@estg.ipp.pt"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("createAdminAccount")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Create Admin", Description = "Create Admin on DataBase")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateUserHP user)
        {
            List<string> erros = _userService.ValidateHighUser(user);
            var Password = _userService.GenerateRandomPassword();

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                _emailService.SendEmailPassword(user, Password);
                await _userService.AddAdmin(user, Password);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes Admin name.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="newName"></param>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT /Todo (Participante)
        ///     {
        ///        "admin"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPut("{adminId}/changeAdminName")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Admin Name", Description = "Change Admin name on DataBase")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> EditAdminName([FromBody] string newName, int adminId)
        {
            try
            {
                await _userService.EditAdminName(newName, adminId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Changes Admin Email.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo (Admin)
        ///     {
        ///        "admin@email.com"
        ///     }
        /// </remarks>
        /// <param name="adminId"></param>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        [HttpPut("{adminId}/changeAdminEmail")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Admin Email", Description = "Change Admin email on DataBase")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> EditAdminEmail([FromBody] string newEmail, int adminId)
        {
            if (_userService.IsValidEmail(newEmail) != true)
            {
                return BadRequest();
            }
            try
            {
                await _userService.EditManagerEmail(newEmail, adminId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Changes Admin password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="adminId"></param>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT /Todo (Admin)
        ///     {
        ///        "asd498s4d"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPut("{adminId}/changeAdminPassword")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Admin Password", Description = "Change Admin Password on DataBase")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> EditAdminPassword([FromBody] string password, int adminId)
        {
            if (password.Trim().Equals("") && password.Trim().Length < 10)
            {
                return BadRequest();
            }

            try
            {
                await _userService.EditPassword(password, adminId, null, null);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes Admin.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     "manager@estg.ipp.pt"
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpDelete("removeAdmin")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Delete Admin", Description = "Deletes Admin on DataBase")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteAdmin([FromBody] string email)
        {
            List<string> erros = new();

            if (_userService.AdminExists(email) != true)
            {
                erros.Add("No Admin exists with this ID");
            }
            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _userService.RemoveAdmin(email);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Gets a list of Managers names
        /// </summary>
        /// <returns>A list of Managers names</returns>
        [HttpGet("getManagers")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "List of Managers names", Description = "Lists of Managers names in DB")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetManagers()
        {
            bool existsM = _userService.ManagerExists();
            if (existsM)
            {
                List<ManagerVM> list = await _userService.GetListedManagers();
                return Ok(list);
            }
            return NotFound();
        }

        /// <summary>
        /// Gets the Manager info
        /// </summary>
        /// <returns>A Manager information</returns>
        [HttpGet("{managerId}/getManagerInfo")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "Manager info", Description = "Return info about the Manager")]
        [Authorize(Roles = "SuperAdmin,Admin,Manager")]
        public async Task<IActionResult> GetManagerInfo(int managerId)
        {
            bool existsM = _userService.ManagerExists();
            if (existsM)
            {
                ManagerVM man = await _userService.ManagerInfo(managerId);
                return Ok(man);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates Manager, and sends email with the credentials.
        /// </summary>
        /// <param name="man"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo (Manager)
        ///     {
        ///        "userName": "manager",
        ///        "email": "manager@estg.ipp.pt",
        ///        "groupId": 0
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("createManagerAccount")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Server Error")]
        [SwaggerOperation(Summary = "Create Manager", Description = "Create Manager on DataBase")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> CreateManager([FromBody] CreateManagerVM man)
        {
            CreateUserHP user = new(man.UserName, man.Email);
            List<string> erros = _userService.ValidateHighUser(user);
            var Password = _userService.GenerateRandomPassword();

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                _emailService.SendEmailPassword(user, Password);
                await _userService.AddManager(user, Password, man.GroupId);
            }
            catch (Exception)
            {
                return BadRequest("Manager add failed");
            }

            return Ok();
        }

        /// <summary>
        /// Changes Manager Display.
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [HttpPut("{managerId}/changeDisplay")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Manager Display", Description = "Change Manager Display on DataBase")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> EditManagerDisplay(int managerId)
        {
            try
            {
                await _userService.EditDisplay(managerId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Changes Manager Display.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo (Manager)
        ///     {
        ///        "manager"
        ///     }
        /// </remarks>
        /// <param name="managerId"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        [HttpPut("{managerId}/changeManagerName")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Manager Name", Description = "Change Manager name on DataBase")]
        [Authorize(Roles = "Admin,SuperAdmin,Manager")]
        public async Task<IActionResult> EditManagerName([FromBody] string newName, int managerId)
        {
            List<string> erros = new();

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }
            if (newName.Equals(""))
            {
                return BadRequest();
            }
            try
            {
                await _userService.EditManagerName(newName, managerId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Changes Manager Email.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Todo (Manager)
        ///     {
        ///        "manager@email.com"
        ///     }
        /// </remarks>
        /// <param name="managerId"></param>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        [HttpPut("{managerId}/changeManagerEmail")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Manager Email", Description = "Change Manager email on DataBase including password")]
        [Authorize(Roles = "Admin,SuperAdmin,Manager")]
        public async Task<IActionResult> EditManagerEmail([FromBody] string newEmail, int managerId)
        {
            if (_userService.IsValidEmail(newEmail) != true)
            {
                return BadRequest();
            }
            try
            {
                await _userService.EditManagerEmail(newEmail, managerId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Changes Manager password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="managerId"></param>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT /Todo (Manager)
        ///     {
        ///        "asd498s4d"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPut("{managerId}/changeManagerPassword")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Manager Password", Description = "Change Manager Password on DataBase")]
        [Authorize(Roles = "SuperAdmin,Admin,Manager")]
        public async Task<IActionResult> EditManagerPassword([FromBody] string password, int managerId)
        {
            if (password.Trim().Equals("") && password.Trim().Length < 10)
            {
                return BadRequest();
            }

            try
            {
                await _userService.EditPassword(password, null, managerId, null);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes Manager.
        /// </summary>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [HttpDelete("{managerId}/removeManager")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Delete Manager", Description = "Deletes Manager on DataBase")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> DeleteManager(int managerId)
        {
            List<string> erros = new();

            if (_userService.ManagerExists(managerId) != true)
            {
                erros.Add("No Admin exists with this ID");
            }
            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _userService.RemoveManager(managerId);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Gets a list of Participantes names
        /// </summary>
        /// <returns>A list of Participantes names</returns>
        [HttpGet("getParticipantes")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "List of Participantes names", Description = "Lists of Participantes names in DB")]
        [Authorize(Roles = "SuperAdmin,Admin,Manager")]
        public async Task<IActionResult> GetParticipantes()
        {
            bool existsM = _userService.ManagerExists();
            if (existsM)
            {
                List<ParticipanteVM> list = await _userService.GetListedParticipantes();
                return Ok(list);
            }
            return NotFound();
        }

        /// <summary>
        /// Gets the Participante info
        /// </summary>
        /// <returns>A Participante information</returns>
        [HttpGet("{participanteId}/getParticipanteInfo")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "Participante info", Description = "Return info about the Participante")]
        [Authorize(Roles = "SuperAdmin,Admin,Participante")]
        public async Task<IActionResult> GetParticipanteInfo(int participanteId)
        {
            bool existsP = _userService.ParticipanteExists();
            if (existsP)
            {
                ParticipanteVM man = await _userService.ParticipanteInfo(participanteId);
                return Ok(man);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates Participante.
        /// </summary>
        /// <param name="user"></param>
        /// <remarks>
        /// Sample request:
        ///     
        ///     POST /Todo (Participante)
        ///     {
        ///        "Email": "participante@estg.ipp.pt",
        ///        "Password": "participantePassword",
        ///        "Wallet": "0x....f" (optional)
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("createParticipanteAccount")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Create Participante", Description = "Create Participante on DataBase")]
        public async Task<IActionResult> CreateParticipante([FromBody] CreateUserVM user)
        {
            List<string> erros = _userService.ValidateLowUser(user);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _userService.AddParticipante(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes Participante wallet.
        /// </summary>
        /// <param name="wallet"></param>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT /Todo (Participante)
        ///     {
        ///        "0xas68f4sadasd"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPut("ChangeWallet")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Participante Wallet", Description = "Change Participante wallet on DataBase")]
        [Authorize(Roles = "Participante")]
        public async Task<IActionResult> EditParticipanteWallet([FromBody] string wallet)
        {
            if (wallet.Trim().Equals(""))
            {
                return BadRequest();
            }

            try
            {
                await _userService.EditWallet(wallet, GetUserNameFromHeader());
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(GetUserNameFromHeader());
            }
        }

        /// <summary>
        /// Changes Participante password.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="participanteId"></param>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT /Todo (Participante)
        ///     {
        ///        "asd498s4d"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPut("{participanteId}/changeParticipantePassword")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerOperation(Summary = "Edit Participante Password", Description = "Change Participante Password on DataBase")]
        [Authorize(Roles = "Participante")]
        public async Task<IActionResult> EditParticipantePassword([FromBody] string password, int participanteId)
        {
            if (password.Trim().Equals("") && password.Trim().Length < 10)
            {
                return BadRequest();
            }

            try
            {
                await _userService.EditPassword(password, null, null, participanteId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Login for Users
        /// </summary>
        /// <param name="login"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo (Admin)
        ///     {
        ///        "Email": "admin@estg.ipp.pt",
        ///        "Password": "adminPassword",
        ///        "Priority": "HP" (High Priority)
        ///     }
        ///
        ///     POST /Todo (Manager)
        ///     {
        ///        "Email": "manager@estg.ipp.pt",
        ///        "Password": "managerPassword",
        ///        "Priority": "HP" (High Priority)
        ///     }
        ///     
        ///     POST /Todo (Participante)
        ///     {
        ///        "Email": "participante@estg.ipp.pt",
        ///        "Password": "participantePassword",
        ///        "Priority": "LP" (Low Priority)
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("Login")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "Login", Description = "User Login")]
        public async Task<IActionResult> PostLogin([FromBody] LoginVM login)
        {
            List<string> erros = new();

            if (login.Priority.Equals("HP"))
            {
                erros = _userService.ValidateLoginHighPriority(login);
            }
            else if (login.Priority.Equals("LP"))
            {
                erros = _userService.ValidateLoginLowPriority(login);
            }

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            var log = await _userService.Login(login);
            if (log == null)
            {
                erros.Add("Password incorreta");
                return BadRequest(erros);
            }

            return Ok(log);
        }

        /// <summary>
        /// Login for SA User
        /// </summary>
        /// <param name="login"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///        "UserName": "----", (hidden)
        ///        "Password": "----"  (hidden)
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost("LoginSA")]
        [SwaggerResponse(200, " Ok")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerOperation(Summary = "Login", Description = "User Login")]
        public async Task<IActionResult> PostLoginSA([FromBody] LoginSA login)
        {
            int SAExist = _userService.SuperAdminExists();
            if (SAExist == 0)
            {
                try
                {
                    await _userService.AddSuperAdmin();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            else if (SAExist > 0)
            {
                try
                {
                    await _userService.RemoveAllSuperAdmin();
                    await _userService.AddSuperAdmin();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }

            var log = await _userService.LoginSA(login);
            if (log == null)
            {
                return BadRequest();
            }

            return Ok(log);
        }

        /// <summary>
        /// Get the userName uncrypted
        /// </summary>
        /// <returns>Returns the userName uncrypted or null.</returns>
        private string GetUserNameFromHeader()
        {
            if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                var userName = identity.Claims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
                if (userName != null)
                {
                    return userName;
                }
            }
            throw new Exception();
        }
    }
}
