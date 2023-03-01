using CheapSkies.Controller.Controller;
using CheapSkies.Controller.Controller.Flight_Maintenance_Screen;
using CheapSkies.Controller.Controller.FlightMaintenanceScreen;
using CheapSkies.Controller.Controller.Home_Screen;
using CheapSkies.Controller.Controller.Interface.FlightMaintenancScreen.Interface;
using CheapSkies.Controller.Controller.Interface.HomeScreen.Interface;
using CheapSkies.Controller.Controller.Interface.ReservationScreen.Interface;
using CheapSkies.Controller.Controller.Reservation_Screen;
using CheapSkies.View;
using Microsoft.Extensions.DependencyInjection;

namespace CheapSkiesFinal
{
    public class Program
    {
        public static void Main()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var homeScreenController = serviceCollection.BuildServiceProvider().GetService<IHomeScreenController>();

            homeScreenController.DisplayHomeScreen();

            //var homeScreenController = new HomeScreenController();
            //homeScreenController.DisplayHomeScreen();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            ConfigureControllerServices(services);
            ConfigureRepositoryServices(services);
            ConfigureViewServices(services);
        }

        public static void ConfigureControllerServices(IServiceCollection services)
        {
            services.AddSingleton<IHomeScreenController, HomeScreenController>();

            services.AddSingleton<IFlightMaintenanceController, FlightMaintenanceController>();
            services.AddSingleton<IAddFlightController, AddFlightController>();
            services.AddSingleton<IDisplayFlightController, DisplayFlightController>();
            services.AddSingleton<ISearchFlightController, SearchFlightController>();

            services.AddSingleton<IReservationController, ReservationController>();
            services.AddSingleton<IAddPassengerController, AddPassengerController>();
            services.AddSingleton<ICreateReservationController, CreateReservationController>();
            services.AddSingleton<ISearchReservationController, SearchReservationController>();
        }

        public static void ConfigureRepositoryServices(IServiceCollection services) 
        {
            services.AddSingleton<IFlightMaintenanceController, FlightMaintenanceController>();
            services.AddSingleton<IAddFlightController, AddFlightController>();
            services.AddSingleton<IDisplayFlightController, DisplayFlightController>();
        }

        public static void ConfigureViewServices(IServiceCollection services)
        {
            services.AddSingleton<IUI, UI>();
        }
    }
}