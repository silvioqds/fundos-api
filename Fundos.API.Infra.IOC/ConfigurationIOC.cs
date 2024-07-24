using System;

using Autofac;
using Fundos.API.App.Interface;
using Fundos.API.App.Service;
using Fundos.API.Domain.Core.Repository;
using Fundos.API.Domain.Core.Service;
using Fundos.API.Domain.Service;
using Fundos.API.Infra.Repo;

namespace Fundos.API.Infra.IOC
{
    public class ConfigurationIOC
    {
        public static void Loader(ContainerBuilder builder)
        {

            #region Application Services
            builder.RegisterType<AppFundo>().As<IAppFundo>();
            builder.RegisterType<AppTipoFundo>().As<IAppTipoFundo>();

            #endregion

            #region Services
            builder.RegisterType<FundoService>().As<IFundoService>();
            builder.RegisterType<TipoFundoService>().As<ITipoFundoService>();
            #endregion

            #region Repositorys
            builder.RegisterType<FundoRepository>().As<IFundoRepository>();
            builder.RegisterType<TipoFundoRepository>().As<ITipoFundoRepository>();
            #endregion
        }

    }
}
