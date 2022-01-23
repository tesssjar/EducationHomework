using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarineShips;

namespace Fields
{
    public class Field
    {
        public Field(int Length) 
        {
            Length = Length;
        }

        public int Length { get; set; }
        public List<Ship> ships { get; set; }

        public static bool IsEnoughSpace(List<int> Location, int Length, List<Ship> ships) 
        {
            if (Location[1] > Length || Location[0] > Length || Location[1] < -Length || Location[0] < -Length ||
                Location[3] > Length || Location[2] > Length || Location[3] < -Length || Location[2] < -Length)
            {
                return false;
            } 
            else 
            { 
                return true; 
            }
        }
        public void AddShip(Ship ship, List<Ship> ships)
        {
            if (IsEnoughSpace(ship.Location, Length, ships)) 
            { 
                ships.Add(ship); 
            }
            else 
            { 
                Console.WriteLine("Cant set the ship here!"); 
            }
        }
    }
}
