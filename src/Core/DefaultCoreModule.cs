using Autofac;

namespace Nikan.Services.Reports.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    //builder.RegisterType<ToDoItemSearchService>()
    //    .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
