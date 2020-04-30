using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCleaner
{
    class Enemy : Entity
    {

        private Levels m_eLevel;
        public Levels Level
        {
            get
            {
                return m_eLevel;
            }

            set
            {
                m_eLevel = value;
                switch (m_eLevel)
                {
                    case Levels.EASY:
                        setValues(5, 0, 0);
                        break;
                    case Levels.MODERATE:
                        setValues(10, 7, 4);
                        break;
                    case Levels.HARD:
                        setValues(15, 10, 7);
                        break;
                    case Levels.DEATH:
                        setValues(20, 13, 10);
                        break;
                    default:
                        break;
                }
            }
        }

        Random random = new Random();
        void setValues(int health, int attack, int defence)
        {
            Health *= health;
            Attack += attack;
            Defence += defence;
        }
        public Enemy() : base()
        {
            Array values = Enum.GetValues(typeof(Enemy_Name));
            Name = values.GetValue(random.Next(values.Length)).ToString();
        }
    }
}
