using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PycApi.Data
{
    //Mapping process for Account class
    public class AccountMap : ClassMapping<Account>
    {
        public AccountMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("Id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Email, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.UserName, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.Password, x =>
            {
                x.Length(150);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Role, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });


            Property(b => b.LastActivity, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });

            Table("account");
        }
    }
}