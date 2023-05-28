using Game2.PlayerFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Magician player = new Magician("Илья", 1, "лёд");
                Slime slime = new Slime("pinky", 1, 35, "red");
                do
                {
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                Battle(player, slime);
                Console.ReadKey();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали другое значение.\n Попробуй снова!\n Нажмите на любую клавишу.");
                Console.ReadKey();
            }
        }

        private static void RedactorText(string text)
        {
            int i = 0;
            foreach (var lettre in text)
            {
                i++;
                Thread.Sleep(60);
                Console.Write(lettre);
                if (i >= 100 && Convert.ToString(lettre) == " ")
                    Console.Write("\n");

            }
        }

        public static void Battle(Magician player, Enemy enemy)
        {
            Random chance = new Random();
            Console.WriteLine("Бой начался");
            while (player.HitPoints >= 0 && enemy.HitPoints >= 0)
            {
                try
                {

                    Console.WriteLine("Ход игрока. Выберите действие.\n" +
                                      "Физическая атака: 1\n" +
                                      "Заклинание: 2\n" +
                                      "Пропустить ход: 3");

                    Console.Write("--->");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            double hit = (player.Hit() <= enemy.ResistancePhysical ? 0 : player.Hit() - enemy.ResistancePhysical) *
                                                  (chance.Next(1, 101) <= player.CritChance * 100 ? 1 + player.CritDamage : 1);
                            enemy.HitPoints -= hit;
                            Console.WriteLine($"Игрок сходил. ({(hit <= 0 ? " " : Convert.ToString(hit) + " физ. урона)")}");
                            break;
                        case 2:
                            double maghit = (player.UsageMagicSkill() <= enemy.ResistanceMagic ? 0 : player.UsageMagicSkill() - enemy.ResistanceMagic) *
                                                (chance.Next(1, 101) <= player.CritChance * 100 ? 1 + player.CritDamage : 1);

                            enemy.HitPoints -= maghit;
                            Console.WriteLine($"Игрок сходил. ({(maghit <= 0 ? " " : Convert.ToString(maghit) + " маг. урона)")}");
                            break;
                        case 3: break;
                    }

                    RedactorText(". . .\n");
                    double enemyHit = (enemy.Damage <= player.ResistancePhysical ? 0 : enemy.Damage - player.ResistancePhysical);
                    player.HitPoints -= enemyHit;
                    Console.WriteLine("Монстр ударил. (" + (enemyHit <= 0 ? " И не смог пробить броню " : Convert.ToString(enemyHit) + " урона.)"));
                    player.InfoPlayer();
                    Console.WriteLine("");
                    enemy.InfoEnemy();
                    Console.ReadKey();
                    Console.Clear();
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Вы выбрали другое значение.\n Попробуй снова!\n Нажмите на любую клавишу.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            if (enemy.HitPoints <= 0)
            {
                Console.WriteLine("Победил игрок");
                player.CheckLevel(100 * enemy.Level);
            }
            else
                Console.WriteLine("капец тылох. ты здох");
        }
    }
}

