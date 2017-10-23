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
                     .ConnectionString(x => x.Username("LucasAssis_SQLLogin_1").Password("z2ncixmf1v").Database("MYBANDS").Server("MYBANDS.mssql.somee.com"))
                     //.ConnectionString(x => x.Username("PROGRAMMERS\\cleiton.barbieri").Database("MYBAND").Server("N174").TrustedConnection())
                     //.ConnectionString(x => x.Username("DESKTOP-68RQUIE\\Lucas").Database("MYBAND").Server("DESKTOP-68RQUIE\\SQLEXPRESS").TrustedConnection())
                            .ShowSql()
                   )
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserModel>())
                  .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                  //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false,true))
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