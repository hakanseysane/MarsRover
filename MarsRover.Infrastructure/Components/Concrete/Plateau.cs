using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Infrastructure.Components.Concrete
{
    public class Plateau
    {
        public Plateau(int rows, int columns)
        {
            Grid = GenerateGrid(rows, columns);

        }
        public int[,] Grid { get; set; }

        private int[,] GenerateGrid(int rows, int columns)
        {
            int[,] grid = new int[rows, columns];
            int number = 1;

            for (int i = 0; i != rows; i++)
            {
                for (int j = 0; j != columns; j++)
                {
                    grid[i, j] = number;
                    number++;
                }
            }

            return grid;
        }
    }
}
