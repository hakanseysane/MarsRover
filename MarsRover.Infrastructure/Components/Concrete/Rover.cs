using MarsRover.Infrastructure.Components.Abstract;
using MarsRover.Infrastructure.Enumerations;
using MarsRover.Infrastructure.Helpers;
using MarsRover.Infrastructure.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace MarsRover.Infrastructure.Components.Concrete
{
    public class Rover : IRover
    {
        public Rover()
        {
            this.Coordinates = new Point(0, 0);
            this.Direction = Direction.North;
        }

        public void ExecCommand(char command) {
            switch (command)
            {
                case 'L':
                    Direction = TurnLeft(Direction);
                    break;
                case 'R':
                    Direction = TurnRight(Direction);
                    break;
                case 'M':
                    Move(Direction);
                    break;
                default:
                    break;
            }
        }

        public void SetPosition(int x, int y) {
            Coordinates = new Point(x, y);
        }

        public void SetDirection(Direction direction) 
        {
            Direction = direction;
        }

        public void Move(Direction currentDirection)
        {
            var currentCoordinates = Coordinates;
            var movingValuesString = currentDirection.GetDescription();
            var movingValues = movingValuesString.Split(',').Select(Int32.Parse).ToArray();
            var x = Coordinates.X + movingValues[0];
            var y = Coordinates.Y + movingValues[1];
            Coordinates = new Point(x, y);
        }

        static readonly LinkedList<Direction> DirectionList = new LinkedList<Direction>(new[] {
            Direction.North,
            Direction.West,
            Direction.South,
            Direction.East
        });

        public Direction TurnLeft(Direction currentDirection)
        {
            LinkedListNode<Direction> index = DirectionList.Find(currentDirection);
            return (index.Next ?? index.List.First).Value;
        }

        public Direction TurnRight(Direction currentDirection)
        {
            LinkedListNode<Direction> index = DirectionList.Find(currentDirection);
            return (index.Previous ?? index.List.Last).Value;
        }

        public Point Coordinates { get; set; }
        public Direction Direction { get; set; }
    }
}
