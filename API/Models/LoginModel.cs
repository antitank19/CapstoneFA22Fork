using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
