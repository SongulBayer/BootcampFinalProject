using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto
{
    public class CategoryDto
    {
        //Category Dto created
        [Required]
        public  string Title { get; set; }
    }
}
