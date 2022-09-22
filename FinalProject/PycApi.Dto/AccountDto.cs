using PycApi.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto
{
    //Account Dto created
    public class AccountDto
    {
        [Required]
        [MaxLength(125)]
        [UserNameAttribute]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Password { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(500)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RoleAttribute]
        public string Role { get; set; }
    }
}
