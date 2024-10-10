using Backend.Models.VM;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Common;
using System.Net.Mail;
using System.Linq;

namespace Backend.Controllers.Services
{
    public class EntityService
    {
        private readonly AppDbContext _context;
        public EntityService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create an Entity in db
        /// </summary>
        /// <param name="entity">Entity that want create in db</param>
        public async Task AddEntity(String entity)
        {
            var _ent = new Entity(entity);
            _context.Entities.Add(_ent);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an entity from the db
        /// </summary>
        /// <param name="entityName">Entity that is to remove"</param>
        public async Task RemoveEntity(string entityName)
        {
            var ent = await _context.Entities.FindAsync(entityName);
            if (ent != null)
            {
                _context.Entities.Remove(ent);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adds a Domain to the Domain Whitelist in db
        /// </summary>
        /// <param name="domain">Domain Whitelist that want create in db</param>
        public async Task AddDomain(string domain)
        {
            var _dom = new WhitelistDomain(domain, GetEntityId());
            _context.WhitelistDomains.Add(_dom);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a Domain from the Domain Whitelist in the db
        /// </summary>
        /// <param name="domain">Domain that is to be removed"</param>
        public async Task RemoveDomain(string domain)
        {
            var _dom = await _context.WhitelistDomains.SingleOrDefaultAsync(u => u.WhitelistedDomain == domain);
            if (_dom != null)
            {
                _context.WhitelistDomains.Remove(_dom);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Edit domain
        /// </summary>
        /// <param name="newDomain"> The new domain to insert</param>
        /// <param name="domain"> Domain to edit</param>
        public async Task EditDomain(string newDomain, string domain)
        {
            var domainDB = await _context.WhitelistDomains.SingleOrDefaultAsync(e => e.WhitelistedDomain.Equals(domain));
            if (domainDB != null)
            {
                domainDB.WhitelistedDomain = newDomain;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adds an Email to the Email Whitelist in db
        /// </summary>
        /// <param name="email">Email Whitelist that want create in db</param>
        public async Task AddEmailWhitelist(string email)
        {
            var _email = new WhitelistEmail(email, GetEntityId());
            _context.WhitelistEmails.Add(_email);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an Email from the Email Whitelist in the db
        /// </summary>
        /// <param name="email">Email Whitelist that is to be removed"</param>
        public async Task RemoveEmailWhitelist(string email)
        {
            var _email = await _context.WhitelistEmails.SingleOrDefaultAsync(u => u.WhitelistedEmail == email);
            if (_email != null)
            {
                _context.WhitelistEmails.Remove(_email);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Edit email
        /// </summary>
        /// <param name="newEmail"> The new email to insert</param>
        /// <param name="email">The email to edit</param>
        public async Task EditEmail(string newEmail, string email)
        {
            var emailDB = await _context.WhitelistEmails.SingleOrDefaultAsync(e => e.WhitelistedEmail.Equals(email));
            if (emailDB != null)
            {
                emailDB.WhitelistedEmail = newEmail;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Edit entity name
        /// </summary>
        /// <param name="newName"> The new name to insert</param>
        public async Task EditEntityName(string newName)
        {
            var entity = await _context.Entities.FirstOrDefaultAsync();
            if (entity != null)
            {
                entity.Name = newName;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Verify if Entity is valid
        /// </summary>
        /// <param name="EntityName">Name of Entity to validate</param>
        /// <returns>A list with errors, or an empty list if there aren't any errors</returns>
        public List<string> ValidateEntity(string EntityName)
        {
            List<string> errors = new();

            if (EntityName.Trim().Equals(""))
            {
                errors.Add("Invalid Entity Name");
            }
            else if (EntityExists(EntityName))
            {
                errors.Add("Entity with this name already exists");
            }
            else if (EntityExists())
            {
                errors.Add("Entity already exists");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Verify if an Entity and exists in DB
        /// </summary>
        /// <param name="EntityName">Entity Name that want to verify in db</param>
        /// <returns>Return true if exists in db;
        /// Return false if doesn´t exist in db;</returns>
        public bool EntityExists(string EntityName)
        {
            if (_context.Entities.Any(e => EntityName.Equals(e.Name)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verify if an Entity already exists in the DB
        /// </summary>
        /// <returns>Return true if exists an Entity in db;
        /// Return false if doesn´t exist in db;</returns>
        public bool EntityExists()
        {
            if (_context.Entities.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the id of the first entity created that exists in DB
        /// </summary>
        /// <returns>Return id</returns>
        public async Task<EntityVM> GetEntity()
        {
            if (EntityExists())
            {
                var entity = await _context.Entities.FirstOrDefaultAsync();

                EntityVM entityVM = new(entity.Id, entity.Name);

                return entityVM;
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Gets the id of the first entity created that exists in DB
        /// </summary>
        /// <returns>Return id</returns>
        public int GetEntityId()
        {
            var entityId = _context.Entities.AsQueryable().First().Id;
            return entityId;
        }

        /// <summary>
        /// Verify if domain is valid
        /// </summary>
        /// <param name="domain">Name of the domain to validate</param>
        /// <returns>A list with errors, or an empty list if there aren't any errors</returns>
        public List<String> ValidateDomain(string domain)
        {
            List<string> errors = new();

            if (domain.Trim().Equals(""))
            {
                errors.Add("Invalid Domain");
            }
            else if (DomainExists(domain))
            {
                errors.Add("Domain with this name already exists");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Verifies if domain already exists in DB
        /// </summary>
        /// <returns>Return bool</returns>
        public bool DomainExists(string domain)
        {
            if (_context.WhitelistDomains.Any(e => domain.Equals(e.WhitelistedDomain)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if domain starts with "@", and adds it if it doesn't
        /// </summary>
        /// <returns>Return string</returns>
        public string CheckDomain(string domain)
        {
            if (domain.StartsWith("@"))
            {
                return domain;
            }
            else
            {
                return domain.Insert(0, "@");
            }
        }

        /// <summary>
        /// Verify if email is valid
        /// </summary>
        /// <param name="email">Name of the domain to validate</param>
        /// <returns>A list with errors, or an empty list if there aren't any errors</returns>
        public List<String> ValidateEmail(string email)
        {
            List<string> errors = new();

            if (email.Trim().Equals(""))
            {
                errors.Add("Invalid Domain");
            }
            else if (EmailExists(email))
            {
                errors.Add("Email with this name already exists");
            }
            else if (EmailIsValid(email))
            {
                errors.Add("Email has a wrong format");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Verifies if email already exists in whitelistEmail table of the DB
        /// </summary>
        /// <returns>Return true if there is, false if there isn't</returns>
        public bool EmailExists(string email)
        {
            if (_context.WhitelistEmails.Any(e => email.Equals(e.WhitelistedEmail)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if email is valid
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>Return true if it is, false if it isn't</returns>
        public bool EmailIsValid(string emailAddress)
        {
            try
            {
                MailAddress m = new(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets whtitelisted domains
        /// </summary>
        /// <returns>Return list of domains</returns>
        public async Task<List<string>> GetListWhitelistedDomains()
        {
            if (ExistsWhitelistedDomains())
            {
                return await _context.WhitelistDomains.Select(n => n.WhitelistedDomain).ToListAsync();
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Gets whitelisted emails
        /// </summary>
        /// <returns>Return list of emails</returns>
        public async Task<List<string>> GetListWhitelistedEmails()
        {
            if (ExistsWhitelistedEmails())
            {
                return await _context.WhitelistEmails.Select(n => n.WhitelistedEmail).ToListAsync();
            }
            throw new Exception("Empty database table");
        }

        /// <summary>
        /// Verifies if there is any whitelisted emails in DB
        /// </summary>
        /// <returns>Return true if there is or false if there isn't</returns>
        public bool ExistsWhitelistedEmails()
        {
            if (_context.WhitelistEmails.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if there is any whitelisted domains in DB
        /// </summary>
        /// <returns>Return true if there is or false if there isn't</returns>
        public bool ExistsWhitelistedDomains()
        {
            if (_context.WhitelistDomains.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Adds a Group to db
        /// </summary>
        /// <param name="name">Name of the group to add to db</param>
        public async Task AddGroup(string name)
        {
            var _group = new Group(name, GetEntityId());
            _context.Groups.Add(_group);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a Group from db
        /// </summary>
        /// <param name="id">Id of the group to remove from db</param>
        public async Task RemoveGroup(int id)
        {
            var _group = await _context.Groups.FindAsync(id);
            if (_group != null)
            {
                _context.Groups.Remove(_group);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Verifies if there is any group in DB
        /// </summary>
        /// <returns>Return true if there is or false if there isn't</returns>
        public bool ExistsGroup()
        {
            if (_context.Groups.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if there is any group in DB
        /// </summary>
        /// <param name="id">Id of the group</param>
        /// <returns>Return true if there is or false if there isn't</returns>
        public bool ExistsGroup(int id)
        {
            if (_context.Groups.Any(e=>e.Id ==id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if there is any group in DB
        /// </summary>
        /// <param name="name">Name of the group</param>
        /// <returns>Return true if there is or false if there isn't</returns>
        public bool ExistsGroup(string name)
        {
            if (_context.Groups.Any(e=> e.Name.Equals(name)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verify if group is valid
        /// </summary>
        /// <param name="name">Name of the group to validate</param>
        /// <returns>A list with errors, or an empty list if there aren't any errors</returns>
        public List<String> ValidateGroup(string name)
        {
            List<string> errors = new();

            if (name.Trim().Equals(""))
            {
                errors.Add("Invalid Group Name");
            }
            else if (ExistsGroup(name))
            {
                errors.Add("Group with this name already exists");
            }

            return new List<string>(errors);
        }

        /// <summary>
        /// Edit Group
        /// </summary>
        /// <param name="newGroup"> The new group name to insert</param>
        /// <param name="groupId">The group to edit</param>
        public async Task EditGroup(string newGroup, int groupId)
        {
            var groupDB = await _context.Groups.FindAsync(groupId);
            if (groupDB != null)
            {
                groupDB.Name = newGroup;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets Groups
        /// </summary>
        /// <returns>Return list of group names</returns>
        public async Task<List<GroupVM>> GetListGroups()
        {
            if (ExistsGroup())
            {
                List<GroupVM> list = new();
                var groups = await _context.Groups.ToListAsync();

                foreach(var group in groups)
                {
                    GroupVM groupVM = new(group.Id,group.Name);
                    list.Add(groupVM);
                }
                return list;
            }
            throw new Exception("Empty database table");
        }
        
        /// <summary>
        /// Gets the id of the first entity created that exists in DB
        /// </summary>
        /// <returns>Return id</returns>
        public int GetFirstGroupId()
        {
            var groupId = _context.Groups.AsQueryable().First().Id;
            return groupId;
        }
    }
}
