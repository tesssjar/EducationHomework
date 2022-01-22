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

            
        }
    }
}