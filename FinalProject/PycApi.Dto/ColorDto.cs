using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto
{
    public class ColorDto
    {

        //Color dto created
        [Required]
        public string ColorName { get; set; }
    }
}
