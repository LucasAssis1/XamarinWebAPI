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
                     .ConnectionString(x => x.Username("PROGRAMMERS\\cleiton.barbieri").Database("MYBANDTEST").Server("N174").TrustedConnection())
                                .ShowSql()
                   )
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserModel>())
                   .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                                                   .Execute(true, true))
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