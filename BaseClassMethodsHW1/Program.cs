using System;
using System.Collections.Generic;
using Fields;
using MarineShips;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the length of the field:");
            var Field = new Field(int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter the type of the ship (1 - battle ship, 2 - support ship, 3 - mixed ship)");
            string TypeOfShip = Console.ReadLine();

            Ship ship = new Ship();

            List<Ship> ships = new List<Ship>();

            Console.WriteLine("Enter the length of the ship");
            ship.Length = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the speed of the ship");
            ship.Speed = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the position of the ship. Mind that the position is defined by the quadrant and ship's first cell (x,y)!");
            
            Console.WriteLine("quadrant:");
            ship.Index.Add(int.Parse(Console.ReadLine()));
            
            Console.WriteLine("x:");
            ship.Index.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine("y:");
            ship.Index.Add(int.Parse(Console.ReadLine()));

            Console.WriteLine("direction:");
            ship.Direction = Console.ReadLine();

            ship.Location.Add(ship.Index[1]);
            ship.Location.Add(ship.Index[2]);

            switch (ship.Direction) 
            {
                case "up":
                    ship.Location.Add(ship.Index[1]);
                    ship.Location.Add(ship.Index[2]+ship.Length);
                    break;
                case "down":
                    ship.Location.Add(ship.Index[1]);
                    ship.Location.Add(ship.Index[2] - ship.Length);
                    break;
                case "left":
                    ship.Location.Add(ship.Index[1] - ship.Length);
                    ship.Location.Add(ship.Index[2]);
                    break;
                case "right":
                    ship.Location.Add(ship.Index[1] + ship.Length);
                    ship.Location.Add(ship.Index[2]);
                    break;
            }

            Field.AddShip(ship, ships);
        }
    }
}