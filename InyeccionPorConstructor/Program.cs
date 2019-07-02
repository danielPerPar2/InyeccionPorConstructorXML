using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BMWServices;

namespace InyeccionPorConstructor
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            RegisterInContainer();
            Resolution();
        }

        private static void RegisterInContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BMWAutoService>().SingleInstance();
            builder.RegisterType<FordAutoService>().SingleInstance();
            builder.RegisterType<HondaAutoService>().SingleInstance();
            Container = builder.Build();
        }

        private static void Resolution()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var bmw = scope.Resolve<BMWAutoService>();
                var ford = scope.Resolve<FordAutoService>();
                var honda = scope.Resolve<HondaAutoService>();

                AutoServiceCallerImp serviceCaller = new AutoServiceCallerImp(bmw, ford, honda);
                serviceCaller.CallAutoService();
            }
        }
    }
}
