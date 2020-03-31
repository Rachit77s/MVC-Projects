using System;
using System.Linq;

namespace FindCurrentDirection
{
    class Program
    {
        enum Direction
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3,
            AnticlockwiseWest = -1,
            AnticlockwiseSouth = -2,
            AnticlockwiseEast = -3,
        }

       
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(Direction.Friday);
            //Console.WriteLine((int)Direction.Friday);

            //int finalDirection =  GetDirection("North", "RRRLR");


            int finalDirection = GetDirection("North", "LLLRL");

            Direction finalDirectionEnum = (Direction)finalDirection;

            Console.WriteLine(finalDirectionEnum);
            Console.ReadKey();
        }

        private static int GetDirection(string currentDirection, string directionString)
        {
            //Solution 1 - use the LINQ 'Count' extension method
            int countNumberOfR = directionString.ToUpperInvariant().ToCharArray().Count(c => c == 'R');
            int countNumberOfL = directionString.ToUpperInvariant().ToCharArray().Count(c => c == 'L');

            //Get currently which direction we need to turn L or R
            int differenceBetweenLandR = countNumberOfR - countNumberOfL;

            //Get the currentDirection value in ENUM
            Enum.TryParse(currentDirection, out Direction myStatus);

            // case insensitive
            //Direction getCurrentDirectionEnum = (Direction)Enum.Parse(typeof(Direction), currentDirection, true);

            //int getFinalDirection = ( (int)getCurrentDirectionEnum - differenceBetweenLandR ) % 4;

            int getFinalDirection = ((int)myStatus + differenceBetweenLandR) % 4;

            return getFinalDirection;
        }
    }
}
