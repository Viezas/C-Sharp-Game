using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCleaner
{
    class Battle
    {
        public Hero Hero { get; set; }
        public Enemy Enemy { get; set; }

        private Boolean m_turn = true;

        private bool canContinue;

        private int EnemyHealth;
        private int EnemyAttack;
        private int EnemyDefence;

        private int damage;
        private int ParsedUserAnswer;

        public Battle(Hero hero, Enemy enemy)
        {
            Hero = hero;
            Enemy = enemy;

            EnemyHealth = enemy.Health;
            EnemyAttack = enemy.Attack;
            EnemyDefence = enemy.Defence;

            Console.WriteLine("Un ennemi se présente devant vous ! Vous vous mettez en posture de combat !\n");
            Console.WriteLine("Un rapide analyse de l'ennemi vous révèle ses caractéristiques :\n[1]-Nom : {0}\n[2]-PV : {1}\n[3]-Attaque : {2}\n[4]-Défense : {3}\n", Enemy.Name, EnemyHealth, EnemyAttack, EnemyDefence);


            do
            {
                if (m_turn)
                {
                    do
                    {
                           
                        Console.WriteLine("Quelle action souhaitez-vous exécuter ? \n[1]-Attaquer (inflige {0} points de dégâts) ?\n[2]-Défendre ? (augmente votre défense de 5)", Hero.Attack - EnemyDefence);

                        canContinue = false;

                        String userAnswer = Console.ReadLine();
                        bool isParsable;
                        isParsable = int.TryParse(userAnswer, out ParsedUserAnswer);

                        switch (ParsedUserAnswer)
                        {
                            case 1:
                                if (Hero.Attack > EnemyDefence)
                                {
                                    damage = (Hero.Attack - EnemyDefence);
                                    EnemyHealth -= damage;
                                    Console.WriteLine("\nVous infligez {0} points de dégâts à \"{1}\", son nombre de PV s'élève maintenant à {2}\n", damage, Enemy.Name, EnemyHealth);
                                }
                                else
                                {
                                    EnemyHealth -= 1;
                                    Console.WriteLine("\nLa défense de l'adversaire est plus élevé que vos dégâts ! Vous infligez 1 point de dégât à \"{0}\", son nombre de PV s'élève maintenant à {1}\n", Enemy.Name, EnemyHealth);
                                }
                                canContinue = true;
                                break;
                            case 2:
                                Hero.Defence += 5;
                                Console.WriteLine("\nVous augmentez votre défense de 5 points ! Vous avez {0} de défense\n", Hero.Defence);
                                canContinue = true;
                                break;
                            default:
                                Console.WriteLine("Veuillez entrer une réponse valide !\n");
                                canContinue = false;
                                break;
                        }

                        m_turn = false;

                    } while (!canContinue);
                }  
                else
                {
                    Console.WriteLine("Vous êtes attaqué par \"{0}\" !", Enemy.Name);

                    if (EnemyAttack > Hero.Defence)
                    {
                        damage = EnemyAttack - Hero.Defence;
                        Hero.Health -= damage;
                        Console.WriteLine("Vous recevez {0} points de dégâts de la part de \"{1}\", votre nombre de PV s'élève maintenant à {2}\n", damage, Enemy.Name, Hero.Health);
                    }
                    else
                    {   
                        Hero.Health -= 1;
                        Console.WriteLine("Votre défense est plus élevé que les dégâts de l'adversaire ! Vous recevez 1 point de dégât de la part de \"{0}\", votre nombre de PV s'élève maintenant à {1}\n", Enemy.Name, Hero.Health);
                    }

                    m_turn = true;
                }
            } while (Hero.Health > 0 && EnemyHealth > 0);

            if (Hero.Health <= 0)
            {
                Console.WriteLine("Vous avez été tué ! Appuyez sur n'importe quelle touche pour mettre fin à la partie");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Vous avez tué \"{0}\" ! Appuyez sur n'importe quelle touche pour poursuivre votre aventure.", Enemy.Name);
                Console.ReadKey();
            }
        }
    }
}
