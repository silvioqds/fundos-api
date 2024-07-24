using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundos.API.Infra.IOC
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder container)
        {
            ConfigurationIOC.Loader(container);
        }
    }
}
