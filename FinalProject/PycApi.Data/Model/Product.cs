using System.Collections.Generic;

namespace PycApi.Data
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string  ProductName { get; set; }
        public virtual string  ProductDescription { get; set; }
        public virtual bool IsOfferable { get; set; }
        public virtual int Price { get; set; }
        public virtual bool IsSold  { get; set; }
        public virtual int ColorId { get; set; }
        public virtual int BrandId { get; set; }
        public virtual int  CategoryId { get; set; }
        public virtual int AccountId { get; set; }

    }
}
