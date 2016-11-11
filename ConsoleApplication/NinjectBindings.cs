namespace ConsoleApplication
{
    using Contracts.Services;
    using Interceptors;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Interception.Infrastructure.Language;
    using Ninject.Modules;
    using Services;
    using System.IO;
    using System.Reflection;

    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<IDataService>()
                .To<TrimSpaceDataService>()
                .Intercept()
                .With<TrimmedStringCachingInterceptor>();
        }
    }
}
