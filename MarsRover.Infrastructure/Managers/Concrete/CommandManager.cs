using MarsRover.Infrastructure.Enumerations;
using MarsRover.Infrastructure.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MarsRover.Infrastructure.Managers.Concrete
{
    public class CommandManager : ICommandManager
    {
        public Mission GetMissionViaCommand(string commandText) 
        {
            var commandSet = commandText.Split(Environment.NewLine);
            var plateauDimensionsString = commandSet[0];
            var dimensions = plateauDimensionsString.Split(' ').Select(Int32.Parse).ToArray();

            Mission mission = new Mission
            {
                PlateauDimensions = new Tuple<int, int>(dimensions[0], dimensions[1])
            };

            for (int i = 1; i < commandSet.Length; i += 2)
            {
                Task task = new Task();
                var initialPositionCommands = commandSet[i].Trim().Split(' ');

                task.MovingCommands = commandSet[i + 1].Trim().ToCharArray();

                Position position = new Position
                {
                    Coordinates = new Point(Convert.ToInt32(initialPositionCommands[0]), Convert.ToInt32(initialPositionCommands[1])),
                    Direction = GetDirection(initialPositionCommands[2])
                };

                task.InitialPosition = position;

                mission.Tasks.Add(task);
            }
            return mission;

        }

        public Direction GetDirection(string command)
        {
            return command switch
            {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => Direction.None,
            };
        }
    }

    public class Mission { 
        public Tuple<int, int> PlateauDimensions { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }

    public class Task { 
        public Position InitialPosition { get; set; }
        public char[] MovingCommands { get; set; }
    }

    public class Position { 
        public Point Coordinates { get; set; }
        public Direction Direction { get; set; }
    }
}
