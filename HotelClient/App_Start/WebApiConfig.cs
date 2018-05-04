using InfrastructureLayer.Repositories;
using System.Linq;
using System.Web.Http;
using ApplicationLayer.Customer;
using ApplicationLayer.Hotel;
using InfrastructureLayer.Data;
using Unity;
using Unity.Lifetime;

namespace HotelClient
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            container.RegisterType<HotelDBContext, HotelDBContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerRepository, CustomerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IHotelRepository, HotelRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IHotelService, HotelService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
