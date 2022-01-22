using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fields;

namespace MarineShips
{
    public abstract class Ship
    {
        public int Length { get; set; }
        public int Speed { get; set; }
        public string Direction { get; set; }
        public List<int> Location { get; set; }
        public List<int> Index { get; set; }
    }

    public class BattleShip : Ship
    {
        public int AttackLength() { return Length + 10 - Speed; }
    }

    public class SupportShip : Ship
    {
        public int FixLength() { return Length + 10 - Speed; }
    }

    public class MixedShip : Ship
    {
        public int FixOrAttackLength() { return Length + 5 - Speed; }
    }

}
     