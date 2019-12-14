using MV.Prometric.DomainServices;
using MV.Prometric.EntityModels;
using MV.Prometric.Repositories;
using MV.Prometric.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace MV.Prometric.Tests.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            MainCommandInfo();

            while (true)
            {
                var inputCommand = Console.ReadLine();
                var isExitTrue = false;
                switch (inputCommand)
                {
                    case "A":
                        {
                            AddNewVehicle();
                            break;
                        }
                    case "G":
                        {
                            GetAllVehicleList();
                            break;
                        }
                    case "E":
                        {
                            isExitTrue = true;
                            break;
                        }
                    default:
                        {
                            InvalidInputAlert(inputCommand);
                            break;
                        }
                }

                if (isExitTrue)
                {
                    break;// this close the application
                }

            }
        }

        private static void MainCommandInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", 100)));
            Console.WriteLine("please enter one of the command [A - add vehicle,G - Get vehicle list,E - exit the application]");
            Console.WriteLine(String.Concat(Enumerable.Repeat("=", 100)));
        }

        private static void InvalidInputAlert(string inputCommand)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("====================== Invalid Command Validation Error ====================");
            if (string.IsNullOrWhiteSpace(inputCommand))
            {
                Console.WriteLine("Invalid commmand: empty or space are not allowed. please enter one of [A,G,E]");
            }

            MainCommandInfo();
        }

        private static void AddNewVehicle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================== Added a new vehicle ====================");
            Console.WriteLine("Please input vehicle details: ");
            Console.WriteLine("e.g.: {'Id': 0, 'ModelName':'New Vehicle',Color:'WWW',MpgValue:12.0}");
            var newVehicle = Console.ReadLine();
            var vehicleService = new VehicleService { 
                UnitOfWork = new UnitOfWork { 
                    DataContext = new DataContext(), 
                    VehicleRepository = new VehicleRepository()
                } 
            };

            var viewModel = JsonConvert.DeserializeObject<VehicleViewModel>(newVehicle.Replace("'", "\""));
            vehicleService.Save(viewModel);

            MainCommandInfo();

        }

        private static void GetAllVehicleList()
        {
            var vehicleService = new VehicleService
            {
                UnitOfWork = new UnitOfWork
                {
                    DataContext = new DataContext(),
                    VehicleRepository = new VehicleRepository()
                }
            };

            var vehicles = vehicleService.GetAll();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================== Vehicle list with calculated milage ====================");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine("Vehicle : {0}", vehicle.ModelName);
            }

            MainCommandInfo();

        }
    }
}
