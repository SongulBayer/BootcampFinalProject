using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Dto

{
    public class OfferDto
    {//Offer dto created
        [Required]
        public  int? Amount { get; set; }
        [Required]
        public int? Percentage { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
