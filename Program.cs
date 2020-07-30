using System;
using System.Collections.Generic;

namespace MarsApplication
{
    class Program
    {
        public static Dictionary<string, int> orientation = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            orientation.Add("N", 1);
            orientation.Add("E", 2);
            orientation.Add("S", 3);
            orientation.Add("W", 4);

            Rover firstRover;
            Rover secondRover;
            string firstRoversPosition;
            string secondRoversPosition;

            Console.WriteLine("Please put the max size of plateau: ");
            String maxSize = Console.ReadLine();
            if (!checkPlateauInformation(maxSize))
                return;
            else
            {
                List<int> maxSizeList = new List<int>();
                maxSizeList.Add(Convert.ToInt32(maxSize.Split(' ')[0]));
                maxSizeList.Add(Convert.ToInt32(maxSize.Split(' ')[1]));
                firstRover = new Rover(maxSizeList);
                secondRover = new Rover(maxSizeList);
            }
        #region setFirstRover
            
            Console.WriteLine("Please type the first rovers position!:");
            String firstRoversInfo = Console.ReadLine();
            if (!checkRoversInformation(firstRoversInfo))
            {    
                return;
            }
            firstRover.setRoversPosition(
                Convert.ToInt32(firstRoversInfo.Trim().Split(' ')[0].ToString())
                , Convert.ToInt32(firstRoversInfo.Trim().Split(' ')[1].ToString())
                , orientation[firstRoversInfo.Trim().Split(' ')[2]]);

            Console.WriteLine("Please type first rovers' actions!:");
            string moves = Console.ReadLine();
            try
            {
                firstRover.actionCommands(moves);
                firstRoversPosition = firstRover.getRoversPosition();
                if (firstRoversPosition == secondRover.getRoversPosition())
                {
                    Console.WriteLine("Cannot move rover because there is another rover at the same place!");
                    firstRover.setRoversPosition(
                Convert.ToInt32(firstRoversInfo.Trim().Split(' ')[0].ToString())
                , Convert.ToInt32(firstRoversInfo.Trim().Split(' ')[1].ToString())
                , orientation[firstRoversInfo.Trim().Split(' ')[2]]);
                }
                else
                {
                    Console.WriteLine("The last position of the first rover should be: " + firstRoversPosition);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

        #endregion
        

        #region setSecondRover
            Console.WriteLine("Please type the second rovers position!:");
            String seconRoversInfo = Console.ReadLine();
            if (!checkRoversInformation(seconRoversInfo))
            {    
                return;
            }  
            firstRoversPosition= firstRover.getRoversPosition();
            if (firstRoversPosition.Trim().Split(' ')[0].ToString() +  firstRoversPosition.Trim().Split(' ')[1].ToString() 
            == seconRoversInfo.Trim().Split(' ')[0].ToString() + seconRoversInfo.Trim().Split(' ')[1].ToString())
            {
                Console.WriteLine("Cannot set rover because there is another rover at the same place!");
                Console.ReadKey();
                return;
            }
            secondRover.setRoversPosition(
                Convert.ToInt32(seconRoversInfo.Trim().Split(' ')[0].ToString())
                , Convert.ToInt32(seconRoversInfo.Trim().Split(' ')[1].ToString())
                , orientation[seconRoversInfo.Trim().Split(' ')[2]]);

            Console.WriteLine("Please type second rovers actions!:");
            moves = Console.ReadLine();
            try
            {
                secondRover.actionCommands(moves);
                secondRoversPosition = secondRover.getRoversPosition();
                if (secondRoversPosition == firstRover.getRoversPosition())
                {
                    Console.WriteLine("Cannot move rover because there is another rover at the same place!");
                    secondRover.setRoversPosition(
                Convert.ToInt32(seconRoversInfo.Trim().Split(' ')[0].ToString())
                , Convert.ToInt32(seconRoversInfo.Trim().Split(' ')[1].ToString())
                , orientation[seconRoversInfo.Trim().Split(' ')[2]]);

                }
                else
                {
                    Console.WriteLine("The last position of the second rover should be: " + secondRoversPosition);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }
        #endregion

        Console.ReadKey();
        }

        static bool checkRoversInformation(string roversInformation)
        {
            bool check = true;
            int firstCoordinate;
            int secondCoordinate;
            if (roversInformation.Split(' ').Length != 3)
            {
                Console.WriteLine("You need to define rover coordinates and rovers orientation.");
                check = false;
                Console.ReadKey();
                return check;
            }
            bool firstCoordinateCheck = int.TryParse(roversInformation.Split(' ')[0].ToString(), out firstCoordinate);
            bool secondCoordinateCheck = int.TryParse( roversInformation.Split(' ')[1].ToString(), out secondCoordinate);
            if (firstCoordinateCheck || secondCoordinateCheck )
            {    
                if (firstCoordinate < 0 || secondCoordinate < 0)
                {
                    Console.WriteLine("Coordinates cannot be lower than zero. Please try again.");
                    check = false;
                    Console.ReadKey();
                }
            }
            else if (!firstCoordinateCheck || !secondCoordinateCheck)
            {
                Console.WriteLine("Please type proper coordinates.");
                check = false;
                Console.ReadKey();
            }
            else if ( !orientation.ContainsKey(roversInformation.Trim().Split(' ')[2]))
            {
                Console.WriteLine("You need to state the orientation, such as; N, E, S, W. Please try again.");
                check = false;
                Console.ReadKey();
            }
            return check;
        }

        static bool checkPlateauInformation(string coordinates)
        {
            bool check = true;
            int firstCoordinate;
            int secondCoordinate;
            if (coordinates.Split(' ').Length != 2)
            {
                Console.WriteLine("You need to define plateau size with two coordinates. Please try again.");
                check = false;
                Console.ReadKey();
            }
            bool firstCoordinateCheck = int.TryParse(coordinates.Split(' ')[0].ToString(), out firstCoordinate);
            bool secondCoordinateCheck = int.TryParse( coordinates.Split(' ')[1].ToString(), out secondCoordinate);
            if (firstCoordinateCheck || secondCoordinateCheck )
            {    
                if (firstCoordinate < 0 || secondCoordinate < 0)
                {
                    Console.WriteLine("Coordinates cannot be lower than zero. Please try again.");
                    check = false;
                    Console.ReadKey();
                }
            }
            else if (!firstCoordinateCheck || !secondCoordinateCheck)
            {
                Console.WriteLine("Please type proper coordinates.");
                check = false;
                Console.ReadKey();
            }
            return check;
        }

    }
}
