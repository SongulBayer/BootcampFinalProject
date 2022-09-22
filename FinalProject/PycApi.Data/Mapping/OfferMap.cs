using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data
//Mapping process for Offer class
{
    public  class OfferMap : ClassMapping<Offer>
    {
        public OfferMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Amount, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            }); 
            Property(b => b.Percentage, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });  Property(b => b.ProductId, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });
            Table("offer");
        }
    }
}
