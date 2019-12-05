using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Projeto.Data.Entities;
using Projeto.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Util
{
    public class HibernateUtil
    {
        private static ISessionFactory sessionFactory;

        public static ISessionFactory SessionFactory(string connectionString)
        {
            if (sessionFactory == null)
            {
                sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.Add<AvaliacaoAtendimentoMap>())
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
                    .BuildSessionFactory();
            }

            return sessionFactory;
        }
    }
}
