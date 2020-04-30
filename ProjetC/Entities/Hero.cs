using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCleaner
{
    class Hero : Entity
    {
        public Hero() : base()
        {
            Health = 50;
            Attack = 25;
            Defence = 15;
        }
    }
}
