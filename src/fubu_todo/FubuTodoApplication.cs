using System.Collections.Generic;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using FubuPersistence;
using FubuPersistence.RavenDb;
using Spark.Compiler;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace fubu_todo
{
    public class FubuTodoApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            return FubuApplication
                .For<TodoFubuRegistry>()
                .StructureMap(() =>
                {
                    var container = ObjectFactory.Container;
                    container.Configure(x => x.AddRegistry<CoreRegistry>());
                    container.Model.EjectAndRemove(typeof (RavenDbSettings));

                    container.Inject(RavenDbSettings.InMemory());

                    return container;
                });
        }
    }

    public class CoreRegistry : Registry
    {
        public CoreRegistry()
        {
            Scan(scanner =>
            {
                PackageRegistry.PackageAssemblies.Each(scanner.Assembly);
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
            });
        }
    }
}