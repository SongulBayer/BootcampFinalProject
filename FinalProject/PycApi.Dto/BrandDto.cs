using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Dto
{
    //Brand Dto created
    public class BrandDto
    {
        [Required]
        public string BrandName { get; set; }
    }
}
