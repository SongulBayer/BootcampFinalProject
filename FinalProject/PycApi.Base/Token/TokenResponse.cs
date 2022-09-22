using System;
using System.ComponentModel.DataAnnotations;

namespace PycApi.Base
{
    public class TokenResponse
    {
        [Display(Name = "Expire Time")]
        public DateTime ExpireTime { get; set; }


        [Display(Name = "Access Token")]
        public string AccessToken { get; set; }


        public string Role { get; set; }

        public string UserName { get; set; }

        public int SessionTimeInSecond { get; set; }
    }
}
