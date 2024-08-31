/*
Author: Vatsal Nileshkumar Shah
        Vaneesh Jha
        Harshpreet Kaur Kochar
        Nehakumari Patel
*/

using System;
using System.Collections.Generic;

namespace BeeBreedingProblem
{
    class Program
    {

        #region Initialization
        private static readonly List<int> firstCellCoords = new List<int>();
        private static readonly List<int> secondCellCoords = new List<int>();
        #endregion

        static void Main(string[] args)
        {
            int firstCellEntered = 0;
            int secondCellEntered = 0;
            const int MAXCELLNUMBER = 10000;
            const int MINCELLNUMBER = 0;

            while (true)
            {
                try
                {
                    Console.Write("Enter first cell number: ");
                    firstCellEntered = int.Parse(Console.ReadLine());
                    Console.Write("Enter second cell number: ");
                    secondCellEntered = int.Parse(Console.ReadLine());
                }
                catch { Console.WriteLine("Enter numbers only !!!"); }

                if (firstCellEntered > MINCELLNUMBER && firstCellEntered <= MAXCELLNUMBER && secondCellEntered > MINCELLNUMBER && secondCellEntered <= MAXCELLNUMBER)
                    break;
                else
                    Console.WriteLine("\nEnter valid numbers for cell !!!\nTry Again\n");
            }

            GetCoordinates(firstCellEntered, secondCellEntered);
        }

        #region Methods
        private static void GetCoordinates(int firstCell, int secondCell)
        {
            const int MAXFIRSTRINGNUMBER = 7;
            int x = 0;
            int y = 0;
            int z = 0;
            int cellNumber = 1;
            int counter = 1;
            int distance = 0;
            int maxNum = Math.Max(firstCell, secondCell);

            if (cellNumber == firstCell || cellNumber == secondCell)
                distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);

            while (cellNumber <= maxNum)
            {
                cellNumber++; y--; z++;

                if (cellNumber == firstCell || cellNumber == secondCell)
                    distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);

                if (cellNumber > MAXFIRSTRINGNUMBER)
                {
                    for (int southWest = 0; southWest < counter - 1; southWest++)
                    {
                        cellNumber++; x--; z++;

                        if (cellNumber == firstCell || cellNumber == secondCell)
                            distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);
                    }
                }

                for (int northWest = 0; northWest < counter; northWest++)
                {
                    cellNumber++; x--; y++;

                    if (cellNumber == firstCell || cellNumber == secondCell)
                        distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);
                }

                for (int north = 0; north < counter; north++)
                {
                    cellNumber++; y++; z--;

                    if (cellNumber == firstCell || cellNumber == secondCell)
                        distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);
                }

                for (int northEast = 0; northEast < counter; northEast++)
                {
                    cellNumber++; x++; z--;

                    if (cellNumber == firstCell || cellNumber == secondCell)
                        distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);
                }

                for (int southEast = 0; southEast < counter; southEast++)
                {
                    cellNumber++; x++; y--;

                    if (cellNumber == firstCell || cellNumber == secondCell)
                        distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);
                }

                for (int south = 0; south < counter; south++)
                {
                    cellNumber++; y--; z++;

                    if (cellNumber == firstCell || cellNumber == secondCell)
                        distance = FindDistance(cellNumber, firstCell, secondCell, x, y, z);
                }

                counter++;
            }

            Console.WriteLine("\nThe distance between cells {0} and {1} is {2}", firstCell, secondCell, distance.ToString());
        }

        private static int FindDistance(int currentCell, int firstCellEntered, int secondCellEntered, int x, int y, int z)
        {
            int distance = 0;

            if (currentCell == firstCellEntered && firstCellCoords.Count != 3)
                firstCellCoords.AddRange(new List<int> { x, y, z });
            else if (currentCell == secondCellEntered && secondCellCoords.Count != 3)
                secondCellCoords.AddRange(new List<int> { x, y, z });

            if (firstCellCoords.Count > 1 && secondCellCoords.Count > 1)
            {
                distance = (Math.Abs(firstCellCoords[0] - secondCellCoords[0])
                    + Math.Abs(firstCellCoords[1] - secondCellCoords[1])
                    + Math.Abs(firstCellCoords[2] - secondCellCoords[2])) / 2;
            }
            return distance;
        }
        #endregion
    }
}
// ref- https://www.redblobgames.com/grids/hexagons/implementation.html
