using MarsRover.Infrastructure.Components.Concrete;
using MarsRover.Infrastructure.Managers.Abstract;
using MarsRover.Infrastructure.Managers.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.Commander
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                                           .AddTransient<ICommandManager, CommandManager>()
                                           .BuildServiceProvider();

            var commandManager = serviceProvider.GetRequiredService<ICommandManager>();

            var commandSet = @"5 5
                            1 2 N
                            LMLMLMLMM
                            3 3 E
                            MMRMMRMRRMMMMM";

            var mission = commandManager.GetMissionViaCommand(commandSet);
            var plateauWidth = mission.PlateauDimensions.Item1;
            var plateauHeight = mission.PlateauDimensions.Item2;

            foreach (var task in mission.Tasks)
            {
                var rover = new Rover();
                rover.SetPosition(task.InitialPosition.Coordinates.X, task.InitialPosition.Coordinates.Y);
                rover.SetDirection(task.InitialPosition.Direction);

                foreach (var movingCommand in task.MovingCommands)
                {
                    rover.ExecCommand(movingCommand);
                }

                if (plateauWidth < rover.Coordinates.X || 
                    plateauHeight < rover.Coordinates.Y || 
                    rover.Coordinates.X < 0 || 
                    rover.Coordinates.Y < 0)
                {
                    throw new Exception("Out of the area!");
                }
                Console.WriteLine($"{rover.Coordinates.X} {rover.Coordinates.Y} {rover.Direction}");
            }

        }
    }
}
