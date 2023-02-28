using CheapSkies.Controller.Controller;
using CheapSkies.Controller.Controller.Home_Screen;
using CheapSkies.Controller.Controller.Reservation_Screen;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;

namespace CheapSkiesFinal
{
    public class Program
    {
        public static void Main()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var homeScreenController = serviceCollection.BuildServiceProvider().GetService<IHomeScreenController>();

            homeScreenController?.DisplayHomeScreen();

            //var homeScreenController = new HomeScreenController();
            //homeScreenController.DisplayHomeScreen();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureControllerServices(services);
            ConfigureRepositoryServices(services);
        }

        public static void ConfigureControllerServices(IServiceCollection services)
        {
            services.AddSingleton<IHomeScreenController, HomeScreenController>();
            services.AddSingleton<IFlightMaintenanceController, FlightMaintenanceController>();
            services.AddSingleton<IReservationController, ReservationController>();
        }

        public static void ConfigureRepositoryServices(IServiceCollection services) 
        { 
        
        }
    }
}