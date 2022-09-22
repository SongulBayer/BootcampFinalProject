using System.ComponentModel.DataAnnotations;

namespace PycApi.Base
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(125)]
        [UserNameAttribute]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
