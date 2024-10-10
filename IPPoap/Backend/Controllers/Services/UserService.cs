using Backend.Common;
using Backend.Models.VM;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace Backend.Controllers.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly EntityService _entity;

        public UserService(IConfiguration configuration, AppDbContext context, EntityService entity)
        {
            _context = context;
            _configuration = configuration;
            _entity = entity;
        }

        private string GetJwtKey()
        {
            var jwt = _configuration["Jwt:Key"];
            if (jwt != null)
            {
                return jwt;
            }
            else { return "EMPTY"; }
        }

        private string GetSAUserName()
        {
            var name = _configuration["SuperAdminCreds:name"];
            if (name != null)
            {
                return name;
            }
            else { return "EMPTY"; }
        }

        private string GetSAPass()
        {
            var pass = _configuration["SuperAdminCreds:password"];
            if (pass != null)
            {
                return pass;
            }
            else { return "EMPTY"; }
        }

        /// <summary>
        /// API login to get authentication token
        /// </summary>
        /// <param name="login">LoginVM with authentication credentials</param>
        public async Task<Tuple<TokenVM, string, int>?> Login(LoginVM login)
        {
            var admin = await _context.Admins.SingleOrDefaultAsync(u => u.Email == login.Email);
            var participante = await _context.Participantes.SingleOrDefaultAsync(u => u.Email == login.Email);
            var manager = await _context.Managers.SingleOrDefaultAsync(u => u.Email == login.Email);

            if (admin != null && login.Priority.Equals("HP"))
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, admin.Password);
                if (isValidPassword)
                {
                    return new Tuple<TokenVM, string, int>(new TokenVM(GenerateToken(admin.Name, "Admin"), admin.Name), "Admin", admin.Id);
                }
                return null;
            }
            else if (manager != null && login.Priority.Equals("HP"))
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, manager.Password);
                if (isValidPassword)
                {
                    return new Tuple<TokenVM, string, int>(new TokenVM(GenerateToken(manager.Name, "Manager"), manager.Name), "Manager", manager.Id);
                }
                return null;
            }
            else if (participante != null && login.Priority.Equals("LP"))
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, participante.Password);
                if (isValidPassword)
                {
                    return new Tuple<TokenVM, string, int>(new TokenVM(GenerateToken(participante.Email, "Participante"), participante.Email), "Participante", participante.Id);
                }
                return null;
            }
            throw new Exception();
        }

        /// <summary>
        /// API login to get authentication token
        /// </summary>
        /// <param name="login">LoginVM with authentication credentials</param>
        public async Task<TokenVM> LoginSA(LoginSA login)
        {
            var superAdmin = await _context.SuperAdmins.SingleOrDefaultAsync(u => u.Name == login.Username);

            if (superAdmin != null)
            {
                return new TokenVM(GenerateToken(superAdmin.Name, "SuperAdmin"), superAdmin.Name);
            }
            throw new Exception();
        }

        /// <summary>
        /// Removes an admin from the list of admins
        /// </summary>
        public async Task RemoveAllSuperAdmin()
        {
            var superAdmin = await _context.SuperAdmins.ToListAsync();
            if (superAdmin != null)
            {
                _context.SuperAdmins.RemoveRange(superAdmin);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Verifies if an admin exists in DB
        /// </summary>
        /// <param name="email">Id of the admin that is to be verified if exists"</param>
        public bool AdminExists(string email)
        {
            return _context.Admins.Any(e => email.Equals(e.Email));
        }

        /// <summary>
        /// Verifies if any admin exists in DB
        /// </summary>
        public bool AdminExists()
        {
            return _context.Admins.Any();
        }

        /// <summary>
        /// Verifies if a manager exists in DB
        /// </summary>
        /// <param name="managerId">Id of the manager that is to be verified if exists"</param>
        public bool ManagerExists(int managerId)
        {
            return _context.Managers.Any(e => managerId.Equals(e.Id));
        }

        /// <summary>
        /// Verifies if any manager exists in DB
        /// </summary>
        public bool ManagerExists()
        {
            return _context.Managers.Any();
        }

        /// <summary>
        /// Verifies if any participante exists in DB
        /// </summary>
        public bool ParticipanteExists()
        {
            return _context.Participantes.Any();
        }

        /// <summary>
        /// Gets Admins list
        /// </summary>
        /// <returns>Return list of admins names</returns>
        public async Task<List<string>> GetAdminsList()
        {
            if (AdminExists())
            {
                return await _context.Admins.Select(n => n.Name).ToListAsync();
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Gets Managers list
        /// </summary>
        /// <returns>Return list of managers</returns>
        public async Task<List<ManagerVM>> GetListedManagers ()
        {
            if (ManagerExists())
            {
                List<ManagerVM> list = new();
                var managers = await _context.Managers.ToListAsync();

                foreach (var manager in managers)
                {
                    var count = _context.Events.Where(x => x.ManagerId.Equals(manager.Id)).Count();
                    ManagerVM managerVm = new(manager.Id, manager.Name, manager.Email, count, manager.Display, manager.GroupId);
                    list.Add(managerVm);
                }
                return list;
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Gets Participantes list
        /// </summary>
        /// <returns>Return list of Participantes</returns>
        public async Task<List<ParticipanteVM>> GetListedParticipantes()
        {
            if (ParticipanteExists())
            {
                List<ParticipanteVM> list = new();
                var participantes = await _context.Participantes.ToListAsync();

                foreach (var participante in participantes)
                {
                    ParticipanteVM participanteVm = new(participante.Id, participante.Email, participante.Wallet);
                    list.Add(participanteVm);
                }
                return list;
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Edit Admin name
        /// </summary>
        /// <param name="newName">New name for the admin</param>
        /// <param name="adminId">Id of the Admin to change name</param>
        public async Task EditAdminName(string newName, int adminId)
        {
            var user = await _context.Admins.FindAsync(adminId);
            if (user != null)
            {
                user.Name = newName;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets user info
        /// </summary>
        /// <param name="adminId">Id of the Admin </param>
        public async Task<AdminVM> AdminInfo(int adminId)
        {
            var user = await _context.Admins.FindAsync(adminId);
            if (user != null)
            {
                var count = _context.Events.Where(x => x.AdminId.Equals(adminId)).Count();
                AdminVM adm = new(user.Id, user.Name, user.Email, count);
                return adm;
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Gets user info
        /// </summary>
        /// <param name="managerId">Id of the Manager </param>
        public async Task<ManagerVM> ManagerInfo(int managerId)
        {
            var user = await _context.Managers.FindAsync(managerId);
            if (user != null)
            {
                var count = _context.Events.Where(x => x.ManagerId.Equals(managerId)).Count();
                ManagerVM man = new(user.Id, user.Name, user.Email, count, user.Display, user.GroupId);
                return man;
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Gets user info
        /// </summary>
        /// <param name="participanteId">Id of the Participante</param>
        public async Task<ParticipanteVM> ParticipanteInfo(int participanteId)
        {
            var user = await _context.Participantes.FindAsync(participanteId);
            if (user != null)
            {
                ParticipanteVM par = new(user.Id, user.Email, user.Wallet);
                return par;
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Edit Admin name
        /// </summary>
        /// <param name="newEmail">New email for the admin</param>
        /// <param name="adminId">Id of the Admin to change name</param>
        public async Task EditAdminEmail(string newEmail, int adminId)
        {
            var user = await _context.Admins.FindAsync(adminId);
            if (user != null)
            {
                user.Email = newEmail;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Removes an admin from the list of admins
        /// </summary>
        /// <param name="email">Id of the admin that is to be removed"</param>
        public async Task RemoveAdmin(string email)
        {
            var admin = await _context.Admins.SingleOrDefaultAsync(u=> u.Email.Equals(email));
            if(admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Removes a manager from the list of managers
        /// </summary>
        /// <param name="managerId">Email of the manager that is to be removed"</param>
        public async Task RemoveManager(int managerId)
        {
            var manager = await _context.Managers.FindAsync(managerId);
            if (manager != null)
            {
                _context.Managers.Remove(manager);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Edit Manager name
        /// </summary>
        /// <param name="newName">New name for the admin</param>
        /// <param name="managerId">Id of the Manager to change name</param>
        public async Task EditManagerName(string newName, int managerId)
        {
            var user = await _context.Managers.FindAsync(managerId);
            if (user != null)
            {
                user.Name = newName;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Edit Manager name
        /// </summary>
        /// <param name="newEmail">New email for the manager</param>
        /// <param name="managerId">Id of the Manager to change name</param>
        public async Task EditManagerEmail(string newEmail, int managerId)
        {
            var user = await _context.Managers.FindAsync(managerId);
            if (user != null)
            {
                user.Email = newEmail;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Edit Manager display
        /// </summary>
        /// <param name="managerId">Id of the Manager to change display</param>
        public async Task EditDisplay(int managerId)
        {
            var user = await _context.Managers.FindAsync(managerId);
            if (user != null)
            {
                if (user.Display)
                {
                    user.Display = false;
                    await _context.SaveChangesAsync();
                } 
                else
                {
                    user.Display = true;
                    await _context.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Create a Super Admin in db
        /// </summary>
        public async Task AddSuperAdmin()
        {
            var password = GetSAPass();
            var name = GetSAUserName();
            var _user = new SuperAdmin(name, BCrypt.Net.BCrypt.HashPassword(password));
            _context.SuperAdmins.Add(_user);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Edit Participante wallet
        /// </summary>
        /// <param name="wallet"> Participante wallet to change</param>
        /// <param name="email">Participiante email of the user to change wallet</param>
        public async Task EditWallet(string wallet, string email)
        {
            var user = await _context.Participantes.SingleOrDefaultAsync(e=>e.Email.Equals(email));
            if (user != null)
            {
                user.Wallet = wallet;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Edit password
        /// </summary>
        /// <param name="newPassword"> New password</param>
        /// <param name="adminId">Admin id to change password</param>
        /// <param name="managerId">Manager id to change password</param>
        /// <param name="participanteId">Participante id to change password</param>
        public async Task EditPassword(string newPassword, int? adminId, int? managerId, int? participanteId)
        {
            var part = await _context.Participantes.FindAsync(participanteId);
            var man = await _context.Managers.FindAsync(managerId);
            var adm = await _context.Admins.FindAsync(adminId);
            if (adminId != null && adm != null)
            {
                adm.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                await _context.SaveChangesAsync();
            }
            if (managerId != null && man != null)
            {
                man.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                await _context.SaveChangesAsync();
            }
            if (participanteId != null && part != null)
            {
                part.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Generate JW Token
        /// </summary>
        /// <param name="username"> Username to encrypt</param>
        /// <param name="role">Role to encrypt</param>
        /// <returns>String with Token</returns>
        private string GenerateToken(string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken
            (
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GetJwtKey())),
                    SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        /// <summary>
        /// Verify if VM is valid for Manager or Admin
        /// </summary>
        /// <param name="login">LoginVM to validate</param>
        /// <returns>A List of strings object with errors , or an empty on if there aren't any errors</returns>
        public List<string> ValidateLoginHighPriority(LoginVM login)
        {
            List<string> errors = new();

            if (!_entity.EntityExists())
            {
                errors.Add("There is no Entity created");
            }
            else if (!IsValidEmail(login.Email))
            {
                errors.Add("Invalid Email");
            }
            else if (!UserExistsHighPrority(login.Email))
            {
                errors.Add("User doesn't Exist");
            }
            else if (login.Password.Trim().Equals(""))
            {
                errors.Add("Invalid Password");
            }
            return errors;
        }

        /// <summary>
        /// Verify if VM is valid for Participante
        /// </summary>
        /// <param name="login">LoginVM to validate</param>
        /// <returns>A List of strings object with errors , or an empty on if there aren't any errors</returns>
        public List<string> ValidateLoginLowPriority(LoginVM login)
        {
            List<string> errors = new();

            if (!_entity.EntityExists())
            {
                errors.Add("There is no Entity created");
            }
            else if (!IsValidEmail(login.Email))
            {
                errors.Add("Invalid Email");
            }
            else if (!UserExistsLowPrority(login.Email))
            {
                errors.Add("User doesn't Exist");
            }
            else if (login.Password.Trim().Equals(""))
            {
                errors.Add("Invalid Password");
            }
            return errors;
        }

        /// <summary>
        /// Verify if the email is valid
        /// </summary>
        /// <param name="email">Email to validate</param>
        /// <returns>Return true if email is valid;
        /// Return false if email isn't valid;</returns>
        public bool IsValidEmail(string email)
        {
            var whitelistDomains = _context.WhitelistDomains;
            var whitelistEmails = _context.WhitelistEmails;

            List<string> domainsList = new();
            List<string> emailsList = new();
            
            foreach(var item in whitelistDomains)
            {
                domainsList.Add(item.WhitelistedDomain);
            }
            foreach (var item in whitelistEmails)
            {
                emailsList.Add(item.WhitelistedEmail);
            }
            
            string emailDomain = email.Split("@")[1].Insert(0, "@");
            bool isValid = false;

            foreach (var item in domainsList)
            {
                if (emailDomain.Equals(item))
                {
                    isValid = true;
                }
            }
            foreach (var item in emailsList)
            {
                if (email.Equals(item))
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Verify how many Super Admins exist in DB
        /// </summary>
        /// <returns>Return the amount of Super Admins that exists in db</returns>
        public int SuperAdminExists()
        {
            var count = _context.SuperAdmins.AsQueryable().Count();
            return count;
        }

        /// <summary>
        /// Verify if a user is a Manager or Admin and exists in DB
        /// </summary>
        /// <param name="email">email of the user that want to verify in db</param>
        /// <returns>Return true if exists in db;
        /// Return false if doesn´t exist in db;</returns>
        public bool UserExistsHighPrority(string email)
        {

            if (_context.Admins.Any(e => email.Equals(e.Email)) || _context.Managers.Any(e => email.Equals(e.Email)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verify if a user is a Participante and exists in DB
        /// </summary>
        /// <param name="email">email of the user that want to verify in db</param>
        /// <returns>Return true if exists in db;
        /// Return false if doesn´t exist in db;</returns>
        public bool UserExistsLowPrority(string email)
        {
            if (_context.Participantes.Any(e => email.Equals(e.Email)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Create an Admin in db
        /// </summary>
        /// <param name="user">User that want create in db</param>
        /// <param name="Password">Password of the User that want create in db</param>
        public async Task AddAdmin(CreateUserHP user, string Password)
        {
            var _user = new Admin(user.UserName, user.Email, BCrypt.Net.BCrypt.HashPassword(Password), _entity.GetEntityId());
            _context.Admins.Add(_user);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Create a Manager in db
        /// </summary>
        /// <param name="user">User that want create in db</param>
        /// <param name="Password">Password of the User that want create in db</param>
        /// <param name="groupId">Id of the group to associate the manager</param>
        public async Task AddManager(CreateUserHP user, string Password, int groupId)
        {
            var _user = new Manager(user.UserName, user.Email, BCrypt.Net.BCrypt.HashPassword(Password), groupId);

            _context.Managers.Add(_user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Create a Participante in db
        /// </summary>
        /// <param name="user">User that want create in db</param>
        public async Task AddParticipante(CreateUserVM user)
        {
            var _user = new Participante(user.Email, BCrypt.Net.BCrypt.HashPassword(user.Password), user.Wallet, _entity.GetEntityId());
            _context.Participantes.Add(_user);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Verify if CreateUserHP is valid for high profile users
        /// </summary>
        /// <param name="user">CreateUserHP to validate</param>
        /// <returns>An ErrorsVM object with errors , or an empty on if there aren't any errors</returns>
        public List<string> ValidateHighUser(CreateUserHP user)
        {
            List<string> errors = new();

            if (user.UserName.Trim().Equals(""))
            {
                errors.Add("Invalid UserName");
            }
            else if (!IsValidEmail(user.Email))
            {
                errors.Add("Email invalid");
            }
            else if(UserExistsHighPrority(user.Email))
            {
                errors.Add("Email already exists");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Verify if CreateUserVM is valid for low profile users
        /// </summary>
        /// <param name="user">CreateUserVM to validate</param>
        /// <returns>An ErrorsVM object with errors , or an empty on if there aren't any errors</returns>
        public List<string> ValidateLowUser(CreateUserVM user)
        {
            List<string> errors = new();
            if (user.Password.Trim().Equals(""))
            {
                errors.Add("Invalid Password");
            }
            else if (!IsValidEmail(user.Email))
            {
                errors.Add("Email invalid");
            }
            else if (UserExistsLowPrority(user.Email))
            {
                errors.Add("Email already exists");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Generates a Random Password
        /// respecting the given strength requirements.
        /// </summary>
        /// <param name="opts">A valid PasswordOptions object
        /// containing the password strength requirements.</param>
        /// <returns>A random password</returns>
        public string GenerateRandomPassword(PasswordOptions? opts = null)
        {
            if (opts == null)
            {
                opts = new PasswordOptions()
                {
                    RequiredLength = 10,
                    RequiredUniqueChars = 0,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = true
                };
            }

            string[] randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
            };

            Random rand = new(Environment.TickCount);
            List<char> chars = new();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        /// <summary>
        /// Gets the id of the first entity created that exists in DB
        /// </summary>
        /// <returns>Return id</returns>
        public int GetAdminId()
        {
            var adminId = _context.Entities.AsQueryable().First().Id;
            
            return adminId;
        }
    }
}
