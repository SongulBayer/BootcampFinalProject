using System.ComponentModel.DataAnnotations;

namespace PycApi.Data
{//Color model created
    public class Color
    {
        public virtual int Id { get; set; } 
        public virtual string ColorName { get; set; }
    }
}
