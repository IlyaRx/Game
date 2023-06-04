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
        List<ItemPlayer> itemsCommon = new List<ItemPlayer>()// до 15 ед  мана /2
        {
            new ItemCloth("Мантия ученика мага", "Обычная",5,1,10),
            new ItemCloth("Кожанный костюм", "Обычная",3,11),
            new ItemCloth("Походный костюм травника", "Обычная",10,1,5),
            new ItemCloth("Какие то тряпки", "Обычная",1,3),
            new ItemCloth("Несколько стоёв одежды кристьянина", "Обычная",0,6),
            new ItemWeapon("Палка, вроде с магическая", "Обычная",3,0.2),
            new ItemWeapon("Палка", "Обычная",9),
            new ItemWeapon("Бита", "Обычная",13),
            new ItemWeapon("Палочка ученика", "Обычная",0,0.3),
            new ItemWeapon("Бита с гвоздями", "Обычная",15),
            new ItemWeapon("Посох из дуба", "Обычная",2,0.5),
            new ItemDecoreion("","",0.1,0.1),
        };

        List<ItemPlayer> itemsUncommon = new List<ItemPlayer>()//от 15 до 20 ед. мана /2
        {

        };

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            try
            {
                Magician player = new Magician("Илья", 15, "лёд");
                Slime slime = new Slime("pinky", 1, 35, "red");

                //do
                //{
                //} while (Console.ReadKey().Key != ConsoleKey.Escape);
                //Battle(player, slime);
                player.InfoPlayer();
                Console.ReadKey();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали другое значение.\n Попробуй снова!\n Нажмите на любую клавишу.");
                Console.ReadKey();
            }
        }

        public static void RedactorText(string text)
        {
            int i = 0;
            foreach (var lettre in text)
            {
                i++;
                Thread.Sleep(10);
                Console.Write(lettre);
                if (i >= 200 && Convert.ToString(lettre) == " ")
                {
                    Console.Write("\n");
                    i = 0;
                }

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
                            double plHit = player.Hit();
                            double hit = (plHit <= enemy.ResistancePhysical ? 0 : plHit - enemy.ResistancePhysical) *
                                                  (chance.Next(1, 101) <= player.CritChance * 100 ? 1 + player.CritDamage : 1);
                            enemy.HitPoints -= hit;
                            Console.WriteLine($"Игрок сходил. ({(hit <= 0 ? " " : Convert.ToString(hit) + " физ. урона)")}");
                            break;
                        case 2:
                            double magicSkill = player.UsageMagicSkill();
                            double maghit = (magicSkill <= enemy.ResistanceMagic ? 0 : magicSkill - enemy.ResistanceMagic) *
                                                (chance.Next(1, 101) <= player.CritChance * 100 ? 1 + player.CritDamage : 1);

                            enemy.HitPoints -= maghit;
                            Console.WriteLine($"Игрок сходил. {(maghit <= 0 ? "Ты не смог пробить броню " : "("+ Convert.ToString(maghit) + " маг. урона)")}");
                            break;
                        case 3: break;
                    }

                    RedactorText(". . .\n");
                    double enemyHit = (enemy.Damage <= player.ResistancePhysical ? 0 : enemy.Damage - player.ResistancePhysical);
                    player.HitPoints -= enemyHit;
                    Console.WriteLine("Монстр ударил. " + (enemyHit <= 0 ? " И не смог пробить броню " :"(" + Convert.ToString(enemyHit) + " урона.)"));
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
                player.CheckLevel(100 * enemy.Level * enemy.Bustlevel);
            }
            else
                Console.WriteLine("капец ты лох. ты здох");
        }
    }
}

