using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto
{
    public class ProductDto
    {
        //Product dto created

        public int Id { get; set; }
        [Required]

        [MaxLength(100)]

        public string ProductName { get; set; }

        [Required]

        [MaxLength(500)]
        public string ProductDescription { get; set; }
        [Required]

        public virtual int Price { get; set; }
        [Required]

        public bool IsOfferable { get; set; }
        [Required]

        public virtual bool IsSold { get; set; }
        [Required]

        public virtual int ColorId { get; set; }
        [Required]

        public virtual int BrandId { get; set; }
        [Required]

        public virtual int CategoryId { get; set; }
        [Required]

        public virtual int AccountId { get; set; }

    }
}
