namespace Backend.Models.VM
{
    public class LoginSA
    {
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Class' constructor method
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="password">User's password</param>
        public LoginSA(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
