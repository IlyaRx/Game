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

        public static void Battle(Magician payer, Enemy enemy)
        {
            Random random = new Random();
            while (payer.HitPoints >= 0 && enemy.HitPoints >= 0)
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
                            enemy.HitPoints -= (payer.Hit() - enemy.ResistancePhysical) *
                                                  (random.Next(1, 101) <= payer.CritChance * 100 ? 1 + payer.CritDamage : 1);
                            break;
                        case 2:

                            enemy.HitPoints -= (payer.UsageMagicSkill() - enemy.ResistanceMagic) *
                                              (random.Next(1, 101) <= payer.CritChance * 100 ? 1 + payer.CritDamage : 1); break;
                        case 3: break;
                    }
                    Console.WriteLine("Игрок сходил");
                    Thread.Sleep(600);
                    Console.Write(". ");
                    Thread.Sleep(600);
                    Console.Write(". ");
                    Thread.Sleep(600);
                    Console.Write(". ");
                    payer.HitPoints -= (enemy.Damage - payer.ResistancePhysical);
                    Console.WriteLine("Монстр ударил.");
                    payer.InfoPlayer();
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
                }

            }
            if (enemy.HitPoints <= 0)
            {
                Console.WriteLine("Победил игрок");
                payer.CheckLevel(100 * enemy.Level);
            }

        }

        static void Main(string[] args)
        {
            try
            {
                Magician player = new Magician("Илья", 10, "лёд");
                Slime slime = new Slime("pinky", 10, 35, "red");
                do
                {
                    slime.InfoEnemy();
                    Console.WriteLine("");
                    player.InfoPlayer();
                    //Battle(player, slime);

                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали другое значение.\n Попробуй снова!\n Нажмите на любую клавишу.");
                Console.ReadKey();
            }
        }
    }
}
