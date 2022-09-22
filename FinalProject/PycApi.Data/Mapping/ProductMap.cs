using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data
//Mapping process for Product class
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });
            Property(b => b.ProductName, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.ProductDescription, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.BrandId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            }); Property(b => b.ColorId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Property(b => b.CategoryId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });Property(b => b.IsSold, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });Property(b => b.IsOfferable, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });
           Property(b => b.Price, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });
           

            Table("product");
        }
    }
}
