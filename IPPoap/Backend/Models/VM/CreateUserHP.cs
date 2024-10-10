namespace Backend.Models.VM
{
    public class CreateUserHP
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Class' constructor method
        /// </summary>
        /// <param name="userName">User's unique identifier for admin and/or manager</param>
        /// <param name="email">User's email</param>
        public CreateUserHP(string userName, string email)
        {
            this.UserName = userName;
            this.Email = email;
        }
    }
}
