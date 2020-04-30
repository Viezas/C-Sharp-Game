using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetC.Dungeon;

namespace DungeonCleaner
{
    class Dungeon
    {
        private int m_index = 1;

        public Hero Hero { get; set; }
        public List<Room> Rooms { get; set; }
        public Dungeon()
        {
            
        }

        public void Enter(Hero hero, Levels level)
        {
            Hero = hero;

            Utility.SetHeader("DUNGEON CLEANER");
            Console.WriteLine("Le héro vient de rentrer dans le donjon");

            // Faut faire un système (for) qui crée des rooms (jusqu'à 8) une par une et qui incrémente m_index et qui défini Room.Depth = m_index;
            for (m_index = 1; m_index <= 4; m_index++)
            {
                Room room = new Room(hero, level);

                room.Depth = m_index;
                room.Enter();
            }

            Utility.SetHeader("DUNGEON CLEANER - Donjon réussi");
            Console.WriteLine("Épilogue ~\nAprès avoir combattu les répugnants monstres du donjon notre héro {0} sauva le monde.\nSa bravoure permit aux villageois de vivre en paix et en sécurité...\n", Hero.Name);
            Console.WriteLine("Bravo vous avez terminé le donjon ! Appuyez sur n'importe quelle touche pour mettre fin à cette partie.");
            Console.ReadKey();
        }
    }
}