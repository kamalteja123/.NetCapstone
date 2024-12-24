using System.ComponentModel.DataAnnotations;
namespace UserManagement.Models
{
    public class User
    {
        [Key] 
        public int UId { get; set; }
        public string Email { get; set; } = string.Empty;//here the user name is the email id
        public byte[] Password { get; set; }//password
        public byte[] Key { get; set; }//the key is associadted with the password i.e the hash key
        public string Role { get; set; } = "Patient";
        public string Status { get; set; } = string.Empty;
    }
}
