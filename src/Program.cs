using System;

namespace Hb_mars_rover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Write 'exit' or 'e' to exit");
                var mission = new MarsMission();
                mission.Start(
                    new RoverVehicle("Opportunity"),
                    new RoverVehicle("Curiosity")
                );
                mission.MissionStarted += (obj, _args) =>
                {
                    Console.WriteLine($"Mars mission started with {mission.NumberOfRovers} rovers");
                };
                mission.BeforeRoverChanged += (obj, _args) =>
                {
                    if (_args == null) return;
                    var data = (BeforeRoverChangedArgs)_args;
                    Console.WriteLine($"{data.Rover.ToString()}");
                };
                // mission.RoverCommandExecuted += (obj, args) =>
                // {
                //     if (args == null) return;
                //     var data = (RoverCommandArgs)args;
                //     switch (data.Type)
                //     {
                //         case CommandType.Move:
                //             Console.WriteLine($"Rover moved. {data.Rover.ToString()}");
                //             break;
                //         case CommandType.Rotate:
                //             Console.WriteLine($"Rover rotated. {data.Rover.ToString()}");
                //             break;
                //         case CommandType.SetPosition:
                //             Console.WriteLine($"Rover position set. {data.Rover.ToString()}");
                //             break;
                //         default:
                //             break;
                //     }
                // };

                while (true)
                {
                    try
                    {
                        RoverVehicle currentRover = null;
                        switch (mission.State)
                        {
                            case CommandState.SetPlateauCoordinates:
                                Console.WriteLine("Please enter plataeu coords. (eg -> 5 5):");
                                break;
                            case CommandState.SetRoverPosition:
                                currentRover = mission.GetCurrentRover();
                                Console.WriteLine($"Please enter initial coords and rotation for rover {currentRover.Name}. (eg -> 1 1 N)");
                                break;
                            case CommandState.RunRoverCommand:
                                currentRover = mission.GetCurrentRover();
                                Console.WriteLine($"Please enter command to move rover {currentRover.Name}. (L: left, R: right, M: move)");
                                break;
                            default:
                                break;
                        }
                        var command = Console.ReadLine();
                        if (string.Equals(command, "exit", StringComparison.InvariantCultureIgnoreCase) || command == "e")
                        {
                            break;
                        }
                        else
                        {
                            mission.ExecuteCommand(command);
                        }
                    }
                    catch (MissionOverException)
                    {
                        Console.WriteLine("Mission completed.");
                        Console.WriteLine("Mission results:");
                        var rovers = mission.GetRovers();
                        foreach (var rover in rovers)
                        {
                            Console.WriteLine(rover.ToString());
                        }
                        break;
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine($"Something went wrong. here is what: {ex.Message}");
                        Console.WriteLine("Please try again");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}
