using System.ComponentModel.DataAnnotations;

namespace PycApi.Data
{//Category Dto created
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }

    }
}
