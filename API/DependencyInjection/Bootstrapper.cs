using API.BusinessLogic;
using Autofac;
using Autofac.Integration.WebApi;
using Data.DataContext;
using Data.Repository;
using Data.Repository.EF;
using System.Configuration;
using System.Reflection;
using System.Web.Http;

namespace API.DependencyInjection
{
    public class Bootstrapper
    {
        public static void ConfigureDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;

            builder.RegisterType<EFContext>()
                .AsSelf()
                .WithParameter("connectionString", connectionString);

            builder.RegisterType<PostsRepository>()
                .As<IPostsRepository>();

            builder.RegisterType<FriendsRepository>()
                .As<IFriendsRepository>();
            builder.RegisterType<FriendsRepository>()
                .As<IFriendsRepository>();

            builder.RegisterType<UsersRepository>()
                .As<IUsersRepository>();

            builder.RegisterType<Mapper>()
                .AsSelf();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}