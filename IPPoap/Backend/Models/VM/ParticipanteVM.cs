using System.ComponentModel.DataAnnotations;

namespace Backend.Models.VM
{
    public class ParticipanteVM
    {
        public int Id { get; set; }

        public String Email { get; set; }

        public String Wallet { get; set; }

        public ParticipanteVM(int id, string email, string wallet)
        {
            this.Id = id;
            this.Email = email;
            this.Wallet = wallet;
        }
    }
}
