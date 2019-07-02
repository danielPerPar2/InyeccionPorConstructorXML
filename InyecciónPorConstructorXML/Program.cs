using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using BMWServices;
using Microsoft.Extensions.Configuration;

namespace InyecciónPorConstructorXML
{
    class Program
    {
        private static IContainer Container{ get; set; }
        static void Main(string[] args)
        {
            AddConfiguration();

            BMWAutoService bmw = Container.Resolve<BMWAutoService>();
            FordAutoService ford = Container.Resolve<FordAutoService>();
            HondaAutoService honda = Container.Resolve<HondaAutoService>();

            AutoServiceCallerImp serviceCaller = new AutoServiceCallerImp(bmw, ford, honda);
            serviceCaller.CallAutoService();
        }

        private static void AddConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddXmlFile("componentes_inyectables.xml");
            var config = configBuilder.Build();

            var module = new ConfigurationModule(config);

            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            Container = builder.Build();
        }

        

       

    }
}
