using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DomainModel.Helpers
{
    public class NHibernateHelper
    {
        //private static ISessionFactory _sessionFactory;

        //private static ISessionFactory SessionFactory
        //{
        //    get
        //    {
        //        if (_sessionFactory == null)
        //        {
        //            var configuration = new Configuration();
        //            configuration.Configure();
        //            configuration.AddAssembly(typeof(Operations).Assembly);
        //            // configuration.AddAssembly(typeof(User).Assembly);
        //            _sessionFactory = configuration.BuildSessionFactory();
        //        }
        //        return _sessionFactory;
        //    }
        //}

        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\git\elma_st\elmatest001-master\Web\App_Data\Database1.mdf;Integrated Security=True").ShowSql()
       
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Operation>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
            //return SessionFactory.OpenSession();
        }
    }
}
