using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Data
{
    public class CategoryMap : ClassMapping<Category>
    {
        //Mapping process for Category class

        public CategoryMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Title, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Table("categories");
        }
    }
}
