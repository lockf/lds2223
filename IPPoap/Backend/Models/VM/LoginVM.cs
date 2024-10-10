using System.Text.Json.Serialization;

namespace Backend.Models.VM
{
    /// <summary>
    /// View model class for login request
    /// </summary>
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Priority { get; set; }

        /// <summary>
        /// Class' constructor method
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="priority">Type of User for Login, "HP" for High Priority users or "LP" for Low Priority users</param>
        [JsonConstructor]
        public LoginVM(string email, string password, string priority)
        {
            this.Email = email;
            this.Password = password;
            this.Priority = priority;
        }
    }

}
