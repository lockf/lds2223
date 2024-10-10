using Backend.Controllers.Services;
using Backend.Models;
using Backend.Models.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EntityController : ControllerBase
    {
        private readonly EntityService _entityService;

        public EntityController(EntityService entityService)
        {
            _entityService = entityService;
        }

        /// <summary>
        /// Gets Entity
        /// </summary>
        /// <returns>A list of domains</returns>
        [HttpGet("getEntity"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "Shows Entity", Description = "Shows Entity in DB"),
         Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> GetEntity()
        {
            bool existsE = _entityService.EntityExists();
            if (existsE)
            {
                var ent = await _entityService.GetEntity();
                return Ok(ent);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates Entity.
        /// </summary>
        /// <returns></returns>
        [HttpPost("createEntity"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Create Entity", Description = "Create Entity on DataBase"),
         Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateEntity([FromBody] String entityName)
        {
            List<string> erros = _entityService.ValidateEntity(entityName);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _entityService.AddEntity(entityName);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes Entity name.
        /// </summary>
        /// <param name="newName"></param>
        /// <returns></returns>
        [HttpPut("changeEntityName"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Edit entity name", Description = "Change entity name on DataBase"),
         Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> EditParticipanteWallet([FromBody] string newName)
        {
            if (newName.Trim().Equals(""))
            {
                return BadRequest();
            }

            try
            {
                await _entityService.EditEntityName(newName);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove Entity
        /// </summary>
        /// <returns></returns>
        [HttpDelete("removeEntity"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "Remove Entity", Description = "Removes an entity from the list of entities"),
         Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> RemoveEntity(string entityName)
        {
            bool entityExists = _entityService.EntityExists(entityName);
            if (entityExists)
            {
                try
                {
                    await _entityService.RemoveEntity(entityName);
                    return Ok();
                }
                catch (System.Data.DataException e)
                {
                    return BadRequest(e.StackTrace);
                }
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets Whitelisted Domains
        /// </summary>
        /// <returns>A list of domains</returns>
        [HttpGet("getWhitelistedDomains"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "Whitelist of Domains", Description = "Lists the domains of the whitelist in DB"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetWhitelistedDomains()
        {
            bool existsWD = _entityService.ExistsWhitelistedDomains();
            if (existsWD)
            {
                List<string> list = await _entityService.GetListWhitelistedDomains();
                return Ok(list);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a Domain.
        /// </summary>
        /// <returns></returns>
        [HttpPost("createDomain"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Create Domain", Description = "Create Domain on DataBase"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> CreateDomain([FromBody] String domainName)
        {
            List<string> erros = _entityService.ValidateDomain(domainName);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                domainName = _entityService.CheckDomain(domainName);
                await _entityService.AddDomain(domainName);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes Domain.
        /// </summary>
        /// <param name="newDomain"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpPut("{domain}/changeDomain"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Edit domain", Description = "Change domain on DataBase"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> EditParticipanteWallet([FromBody] string newDomain, string domain)
        {
            if (newDomain.Trim().Equals(""))
            {
                return BadRequest();
            }

            try
            {
                newDomain = _entityService.CheckDomain(newDomain);
                await _entityService.EditDomain(newDomain, domain);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove Domain
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{domain}/removeDomain"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "Remove Domain", Description = "Removes a Domain from the list of WitelistDomains"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> RemoveDomain(string domain)
        {
            bool domainExists = _entityService.DomainExists(domain);
            if (domainExists)
            {
                try
                {
                    await _entityService.RemoveDomain(domain);
                    return Ok();
                }
                catch (System.Data.DataException e)
                {
                    return BadRequest(e.StackTrace);
                }
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets Whitelisted Emails
        /// </summary>
        /// <returns>A list of emails</returns>
        [HttpGet("getWhitelistedEmails"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "Whitelist of Emails", Description = "Lists the emails of the whitelist in DB"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetWhitelistedEmails()
        {
            bool existsWE = _entityService.ExistsWhitelistedEmails();
            if (existsWE)
            {
                List<string> list = await _entityService.GetListWhitelistedEmails();
                return Ok(list);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a Whitelisted Email.
        /// </summary>
        /// <returns></returns>
        [HttpPost("createWhitelistedEmail"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Create Whitelisted Email", Description = "Create Whitelisted Email on DataBase"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> CreateWhitelistedEmail([FromBody] String email)
        {
            bool emailIsValid = _entityService.EmailIsValid(email);

            if (emailIsValid == false)
            {
                return BadRequest();
            }

            try
            {
                await _entityService.AddEmailWhitelist(email);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes email.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        [HttpPut("{email}/changeEmail"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Edit Email", Description = "Change email on DataBase"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> EditEmail([FromBody] string newEmail, string email)
        {
            bool emailIsValid = _entityService.EmailIsValid(newEmail);
            if (!emailIsValid)
            {
                return BadRequest();
            }

            try
            {
                await _entityService.EditEmail(newEmail, email);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove Whitelisted Email
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{email}/removeWhitelistedEmail"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "Remove Whitelisted Email",
             Description = "Removes a Whitelisted Email from the list of WhitelistEmails"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> RemoveWhitelistedEmail(string email)
        {
            bool emailExists = _entityService.EmailExists(email);
            if (emailExists)
            {
                try
                {
                    await _entityService.RemoveEmailWhitelist(email);
                    return Ok();
                }
                catch (System.Data.DataException e)
                {
                    return BadRequest(e.StackTrace);
                }
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Gets Groups
        /// </summary>
        /// <returns>A list of emails</returns>
        [HttpGet("getGroups"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "List of groups", Description = "Lists the groups in DB"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> GetGroups()
        {
            bool existsG = _entityService.ExistsGroup();
            if (existsG)
            {
                List<GroupVM> list = await _entityService.GetListGroups();
                return Ok(list);
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a Group.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost("createGroup"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Create Group", Description = "Create Group on DataBase"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> CreateGroup([FromBody] String name)
        {
            List<String> erros = _entityService.ValidateGroup(name);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _entityService.AddGroup(name);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Changes group name.
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        [HttpPut("{groupId}/changeGroupName"), SwaggerResponse(200, " Ok"), SwaggerResponse(400, "Bad Request"),
         SwaggerOperation(Summary = "Edit Email", Description = "Change email on DataBase"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> EditGroup([FromBody] string newName, int groupId)
        {
            List<String> erros = _entityService.ValidateGroup(newName);

            if (erros.Count != 0)
            {
                return BadRequest(erros);
            }

            try
            {
                await _entityService.EditGroup(newName, groupId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove group
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpDelete("{groupId}/removeGroup"), SwaggerResponse(200, " Ok"), SwaggerResponse(404, "Not Found"),
         SwaggerOperation(Summary = "Remove group", Description = "Removes a group from the DB"),
         Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> RemoveGroup(int groupId)
        {
            bool groupExists = _entityService.ExistsGroup(groupId);
            if (groupExists)
            {
                try
                {
                    await _entityService.RemoveGroup(groupId);
                    return Ok();
                }
                catch (System.Data.DataException e)
                {
                    return BadRequest(e.StackTrace);
                }
            }
            else
            {
                return NotFound();
            }
        }
    }

}
