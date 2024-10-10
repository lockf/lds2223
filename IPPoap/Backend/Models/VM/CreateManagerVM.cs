namespace Backend.Models.VM
{
    public class CreateManagerVM : CreateUserHP
    {
        public int GroupId { get; set; }

        public CreateManagerVM(string userName, string email, int groupId) : base(userName, email)
        {
            this.UserName = userName;
            this.Email = email;
            this.GroupId = groupId;
        }
    }
}
