using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjetC.Dungeon;

namespace DungeonCleaner
{
    enum Levels
    {
        EASY,
        MODERATE,
        HARD,
        DEATH
    }
    class Game
    {
        public Levels Level { get; set; }
        public Hero Hero { get; set; }
        public Game() 
        {
            
        }

        private Boolean nameFlag;
        public void Init()
        {
            Utility.SetHeader("DUNGEON CLEANER");
            Hero hero = new Hero();

            nameFlag = true;

            do {
                Console.Write("Ton voyage est sur le point de commencer, mais d'abord comment t'appelles tu ?\n");
                hero.Name = Console.ReadLine();

                do
                {
                    Console.Write("\nTu t'appelles bien {0} ? (oui/non)\n", hero.Name);

                    String Answer = Console.ReadLine();
                    Answer = Answer.ToLower();

                    if (Answer == "oui")
                    {
                        nameFlag = false;
                        break;
                    }
                    else if (Answer == "non")
                    {
                        Utility.SetHeader("DUNGEON CLEANER");
                        Console.Write("Ah bon ? J'ai du mal comprendre dans ce cas...\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("La réponse entrée n'est pas valide !");
                    }
                }
                while (true);
            }
            while (nameFlag);

            Hero = hero;
        }

        public void Start()
        {
            do
            {
                do
                {
                    Console.WriteLine("\nChoisissez la difficulté générale du jeu\n[1]-EASY ?\n[2]-MODERATE ?\n[3]-HARD ?\n[4]-DEATH ?");
                    string Answer = Console.ReadLine();
                    Level = (Levels) (int.Parse(Answer) - 1);
                    if ((int.Parse(Answer) - 1) > 3 || (int.Parse(Answer) - 1) < 0)
                    {
                        Console.WriteLine("{0} ne correspond à aucune difficulté !", (int.Parse(Answer)));
                    }
                    else
                    {
                        break;
                    }
                }
                while (true);

                Console.WriteLine("\nVotre mode de jeu a été réglé en : {0}", Level);
                Console.WriteLine("Souhaitez-vous valider cette difficulté ? (oui/non)");
                string Validation = Console.ReadLine().ToLower();
                if (Validation == "oui")
                {
                    break;
                }
            }
            while (true);

            Dungeon dungeon = new Dungeon();

            dungeon.Enter(Hero, Level);
        }
    }
}