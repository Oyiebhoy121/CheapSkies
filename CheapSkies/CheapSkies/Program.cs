using CheapSikes.View;
using CheapSkies.Controller.Controller;
using CheapSkies.Model;
using CheapSkies.Validator;
using CheapSkies.View;
using System.Security.Cryptography.X509Certificates;

namespace CheapSkies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Screen screen = new Screen();
            ScreenInputValidator screenInputValidator = new ScreenInputValidator();
            MainController homeScreenController = new HomeScreenController(screen, screenInputValidator);

            string homeScreenInput;

            do
            {
                homeScreenInput = homeScreenController.GetScreenInput(3);
            }   while (decision == "4");
        }
    }
}