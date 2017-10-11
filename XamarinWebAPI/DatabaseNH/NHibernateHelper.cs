using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XamarinWebAPI.Models;

namespace XamarinWebAPI.DatabaseNH
{
    public class NHibernateHelper
    {

        private static ISessionFactory sessionFactory;

        public static void CreateSessionFactory()
        {
            sessionFactory = Fluently.Configure()
                   .Database(MsSqlConfiguration.MsSql2012
                     .ConnectionString(x => x.Username("LucasAssis_SQLLogin_1").Password("z2ncixmf1v").Database("MyBands").Server("MyBands.mssql.somee.com"))
                                .ShowSql()
                   )
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserModel>())
                  .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                  .BuildSessionFactory();
        } 

        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                CreateSessionFactory();
            }
            return sessionFactory.OpenSession();
        }
    }
}