using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Model;
using MyChampions.Controllers;
using StubLib;
using static System.Console;

namespace ConsoleTestsAPI
{
    static class Program
    {
        static IDataManager dataManager = null!;
        static ChampionsController championsController = null!;

        static async Task Main(string[] args)
        {
            try
            {
                using var servicesProvider = new ServiceCollection()
                                .AddSingleton<IDataManager, StubData>()
                                .BuildServiceProvider();

                dataManager = servicesProvider.GetRequiredService<IDataManager>();

                await DisplayMainMenu();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Stopped program because of exception");
                throw;
            }
        }

        public static async Task DisplayMainMenu()
        {
            Dictionary<int, string> choices = new Dictionary<int, string>()
            {
                [1] = "1- Test Champion Controller",
                [99] = "99- Quit"
            };

            while (true)
            {
                int input = DisplayMenu(choices);

                switch (input)
                {
                    case 1:
                        await TestChampionController();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 99:
                        WriteLine("Bye bye!");
                        return;
                    default:
                        break;
                }
            }
        }

        private static int DisplayMenu(Dictionary<int, string> choices)
        {
            int input = -1;
            while (true)
            {
                WriteLine("What is your choice?");
                WriteLine("--------------------");
                foreach (var choice in choices.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value))
                {
                    WriteLine(choice);
                }
                if (!int.TryParse(ReadLine(), out input) || input == -1)
                {
                    WriteLine("I do not understand what your choice is. Please try again.");
                    continue;
                }
                break;
            }
            WriteLine($"You have chosen: {choices[input]}");
            WriteLine();
            return input;
        }

        public static async Task TestChampionController()
        {
            Dictionary<int, string> choices = new Dictionary<int, string>()
            {
                [0] = "0- Get All Champions",
                [1] = "1- Add A Champion",
                [2] = "2- Find A Champion By Name",
            };

            int input = DisplayMenu(choices);

            switch (input)
            {
                case 0:
                    var champions = await championsController.Get(null);
                    break;
                case 2:
                    string name = ReadLine();
                    var champion = await championsController.GetByName(name);
                    break;
            }
        }
    }
}
    
