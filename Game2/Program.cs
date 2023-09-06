﻿using Game2.PlayerFile;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Game2
{
    class Program
    {
        public static int id = 0;
        static List<ItemPlayer> itemsCommon = new List<ItemPlayer>()
        {
            new ItemCloth("Мантия ученика мага", "Обычный",5,1), //0
            new ItemCloth("Кожанный костюм", "Обычный",6,11), //1
            new ItemCloth("Походный костюм травника", "Обычный",10,4), //2
            new ItemCloth("Какие то тряпки", "Обычный",1,3), //3
            new ItemCloth("Несколько стоёв одежды кристьянина", "Обычный",0,6), //4
            new ItemWeapon("Палка, вроде магическая", "Обычный",3,0.2), //5
            new ItemWeapon("Палка", "Обычный",9), //6
            new ItemWeapon("Бита", "Обычный",13), //7
            new ItemWeapon("Палочка ученика", "Обычный",0,0.3),//8
            new ItemWeapon("Бита с гвоздями", "Обычный",15),//9
            new ItemWeapon("Посох из дуба", "Обычный",2,0.5),//10
            new ItemDecoreion("Медное кольцо","Обычный",0.02,0.06),//11
            new ItemDecoreion("Медный браслет","Обычный",0.03,0.04),//12
            new ItemDecoreion("Медная цепочка","Обычный",0.04,0.02),//13
            new ItemDecoreion("Подвеска с трёхлистным клевером","Обычный",0.034,0.02), //14
        };

        static List<ItemPlayer> itemsUncommon = new List<ItemPlayer>()
        {
            new ItemCloth("Защитная накидка ученика мага", "Необычный",10,2), //0
            new ItemCloth("Плохая кольчуга", "Необычный",14,22), //1
            new ItemCloth("Улучшеный походный костюм травника", "Необычный",20,15), //2
            new ItemCloth("Какие то тряпки", "Необычный",2,6), //3
            new ItemCloth("Дорогая одежда крестьянина", "Необычный",0,12), //4
            new ItemWeapon("Палочка, вроде магическая", "Необычный",6,0.4), //5
            new ItemWeapon("Железный меч", "Необычный",24), //6
            new ItemWeapon("Железная бита", "Необычный",26), //7
            new ItemWeapon("Хорошая бита с гвоздями", "Необычный",35), //8
            new ItemWeapon("Посох из ясеня", "Необычный",8,0.5), //9
            new ItemDecoreion("Железное кольцо","Необычный",0.025,0.12), //10
            new ItemDecoreion("Железное браслет","Необычный",0.04,0.08), //11
            new ItemDecoreion("Железное цепочка","Необычный",0.04,0.04), //12
            new ItemDecoreion("Подвеска с трёхлистным клевером","Необычный",0.034,0.05), //13
        };

        static List<ItemPlayer> itemsRare = new List<ItemPlayer>()
        {
            new ItemCloth("Мантия тёмного мага", "Редкий",20,4), //0
            new ItemCloth("Почти новая кольчуга", "Редкий",20,44), //1
            new ItemCloth("Плащь светлого мага", "Редкий",40,20), //2
            new ItemCloth("Железная броня", "Редкий",4,40), //3
            new ItemCloth("Железная броня с золотыми вставками", "Редкий",20,45), //4
            new ItemWeapon("Палочка из бамбука зачарованного леса", "Редкий",12,0.8), //5
            new ItemWeapon("Острый меч бывалго война", "Редкий",36), //6
            new ItemWeapon("Тёмная коса", "Редкий",52), //7
            new ItemWeapon("Палочка из серебряного древа","Редкий",0,1.2), //8
            new ItemWeapon("Двуручный топор", "Редкий",60), //9
            new ItemWeapon("Посох друида", "Редкий",20,2.3), //10
            new ItemDecoreion("Сеоебренное кольцо","Редкий",0.05,0.05), //11
            new ItemDecoreion("Сеоебренный браслет","Редкий",0.075,0.03), //12
            new ItemDecoreion("Золотая цепочка","Редкий",0.055,0.08), //13
            new ItemDecoreion("Подвеска с четырёхлистным клевером","Редкий",0.1,0.1), //14
        };

        static List<ItemPlayer> itemsLegendary = new List<ItemPlayer>()
        {
            new ItemCloth("Броня короля миров", "Легендарный",100,100), //0
            new ItemWeapon("Экскалибур", "Легендарный",100,2), //1
            new ItemDecoreion("Подвеска с пятилистным клевером","Легендарный",2,2), //2
        };

        public static void RedactorText(string text)
        {
            int i = 0;
            foreach (var lettre in text)
            {
                i++;
                Thread.Sleep(60);
                Console.Write(lettre);
                if (i >= 200 && Convert.ToString(lettre) == " ")
                {
                    Console.Write("\n");
                    i = 0;
                }

            }
        }

        private static ItemPlayer GetItemPlayer()
        {
            Random chance = new Random();
            Console.WriteLine("Вы получили: ");
            int chanceItem = chance.Next(1, 101);
            if (chanceItem == 1)
            {
                int idItem = chance.Next(0, 3);
                Console.Write($"\n"
               + $"|| Название: {itemsLegendary[idItem].Name} \n"
               + $"|| Редклсть: {itemsLegendary[idItem].Rare} \n");
                return itemsLegendary[idItem];
            }
            else if (chanceItem <= 5)
            {
                int idItem = chance.Next(0, 15);
                Console.Write($"\n"
               + $"|| Название: {itemsRare[idItem].Name} \n"
               + $"|| Редклсть: {itemsRare[idItem].Rare} \n");
                return itemsRare[idItem];
            }
            else if (chanceItem <= 20)
            {
                int idItem = chance.Next(0, 14);
                Console.Write($"\n"
               + $"|| Название: {itemsUncommon[idItem].Name} \n"
               + $"|| Редклсть: {itemsUncommon[idItem].Rare} \n");
                return itemsUncommon[idItem];
            }
            else if (chanceItem <= 90)
            {
                int idItem = chance.Next(0, 15);
                Console.Write($"\n"
               + $"|| Название: {itemsCommon[idItem].Name} \n"
               + $"|| Редклсть: {itemsCommon[idItem].Rare} \n");
                return itemsCommon[idItem];
            }
            else
            {
                Console.WriteLine("\n Ты не получил предмет");
                return null;
            }
        }


        public static void Battle(Player player, Enemy enemy)
        {
            Console.Clear();
            player.RemInfo();
            Random chance = new Random();
            Console.WriteLine("Бой начался");
            while (player.HitPoints > 0 && enemy.HitPoints > 0)
            {
                try
                {

                    Console.WriteLine("Ход игрока. Выберите действие.\n" +
                                      "Физическая атака: 1\n" +
                                      "Навык/Заклинание: 2\n" +
                                      "Пропустить ход: 3");

                    Console.Write("=>");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            double plHit = player.Hit();
                            double hit = (plHit <= enemy.ResistancePhysical ? 0 : plHit - enemy.ResistancePhysical) *
                                                  (chance.Next(1, 101) <= player.CritChance * 100 ? 1 + player.CritDamage : 1);
                            enemy.HitPoints -= hit;
                            Console.WriteLine($"Игрок сходил. ({(hit <= 0 ? "Ты не смог пробить броню " : Convert.ToString(hit) + " физ. урона)")}");
                            break;
                        case 2:
                            if (player is Magician mag)
                            {
                                double playerSkill = mag.UsageMagicSkill();
                                double maghit = (playerSkill <= enemy.ResistanceMagic ? 0 : playerSkill - enemy.ResistanceMagic) *
                                                    (chance.Next(1, 101) <= player.CritChance * 100 ? 1 + player.CritDamage : 1);

                                enemy.HitPoints -= maghit;
                                Console.WriteLine($"Игрок сходил. {(maghit <= 0 ? "Ты не смог пробить броню " : "(" + Convert.ToString(maghit) + " маг. урона)")}");
                            }
                            else if (player is Berserk ber)
                            {
                                double playerSkill = ber.UsageSkill();
                                double plhit = (playerSkill <= enemy.ResistancePhysical ? 0 : playerSkill - enemy.ResistancePhysical) *
                                                    (chance.Next(1, 101) <= player.CritChance * 100 ? 1 + player.CritDamage : 1);

                                enemy.HitPoints -= plhit;
                                Console.WriteLine($"Игрок сходил. {(plhit <= 0 ? "Ты не смог пробить броню " : "(" + Convert.ToString(plhit) + " физ. урона)")}");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Игрок сходил и пропустил ход.");
                            break;
                    }

                    RedactorText(". . .\n");
                    if (chance.Next(1, 101) > 10)
                    {
                        double enemyHit = (enemy.Damage <= player.ResistancePhysical ? 0 : enemy.Damage - player.ResistancePhysical);
                        player.HitPoints -= enemyHit;
                        Console.WriteLine("Монстр ударил. " + (enemyHit <= 0 ? " И не смог пробить броню " : "(" + Convert.ToString(enemyHit) + " урона.)"));
                    }
                    else
                        Console.WriteLine("Монстр промахнулся.");
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
                player.InsInfo();
                player.CheckLevel(100 * enemy.Level * enemy.Bustlevel);
                player.Inventory.Add(GetItemPlayer());
            }
            else
                Console.WriteLine("капец ты лох. ты здох");
        }

        static void Menu(Player pl)
        {
            while (true)
            {
                try
                {


                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Информация о игроке: 1\n" +
                                          $"Экиперовка: 2\n" +
                                          $"Инвентарь: 3\n" +
                                          $"Способности: 4");
                        Console.Write("=>");
                        string kay = Console.ReadLine();
                        switch (kay)
                        {
                            case "1":
                                pl.InfoPlayer();
                                break;
                            case "2":
                                pl.InfoEquip();
                                break;
                            case "3":
                                pl.CheckInventory();
                                break;
                            case "4":
                                if (pl is Magician magician)
                                    magician.ListMagicSkill();
                                if (pl is Berserk berserk)
                                    berserk.ListSkill();
                                break;
                        }
                        Console.WriteLine("для продолжения надимете любую клавишу...\n" +
                                          "для выхлода из меню нажимете Backspace...");
                    } while (Console.ReadKey().Key != ConsoleKey.Backspace);
                    return;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Вы выбрали другое значение.\n Попробуй снова!\n Нажмите на любую клавишу.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            try
            {
                Slime slime = new Slime("fdsd", 1, 33, "red");

                RedactorText("\tСоздание персанажа...\n");
                RedactorText("\tНазави своего персонажа:\n");
                Magician playerM = null;
                Berserk playerB = null;
                {
                    Console.Write("=>");
                    string name = Console.ReadLine();
                    RedactorText("\tВыберите класс\n" +
                                 "\t1.Маг\t2.Берсерк\n");
                    Console.Write("=>");
                    id = Convert.ToInt32(Console.ReadLine());
                    if (id == 1)
                    {
                        RedactorText("\tВыбели напровление мага\n" +
                                             "\t1.лёд\t2.oгонь\n");
                        Console.Write("=>");
                        int direction = Convert.ToInt32(Console.ReadLine());
                        playerM = new Magician(name, 1, direction == 1 ? "лёд" : "огонь");
                    }
                    else
                        playerB = new Berserk(name, 1);
                    RedactorText("Вы создали персонажа...");
                }
                if (id == 1) playerM.InfoPlayer();
                else playerB.InfoPlayer();

                if (id == 1) Menu(playerM);
                else Menu(playerB);

                if (id == 1) Battle(playerM, slime);
                else Battle(playerB, slime);

                Console.ReadKey();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Вы выбрали другое значение.\n Попробуй снова!\n Нажмите на любую клавишу.");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}

