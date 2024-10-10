namespace Backend.Models.VM
{
    public class CreateUserVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Wallet { get; set; }

        /// <summary>
        /// Class' constructor method
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="Wallet">User's wallet for participante</param>
        public CreateUserVM(string email, string password = "", string Wallet = "")
        {
            this.Email = email;
            this.Password = password;
            this.Wallet = Wallet;
        }
    }
}
