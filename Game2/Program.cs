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



        public static void Battle(Magician player, Enemy enemy)
        {
            Random chance = new Random();
            Console.WriteLine("Бой начался");
            while (player.HitPoints > 0 && enemy.HitPoints > 0)
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
                            Console.WriteLine($"Игрок сходил. {(maghit <= 0 ? "Ты не смог пробить броню " : "(" + Convert.ToString(maghit) + " маг. урона)")}");
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
                player.CheckLevel(100 * enemy.Level * enemy.Bustlevel);
                Console.WriteLine("Вы получили: ");
                int chanceItem = chance.Next(1, 101);
                if (chanceItem == 1)
                {
                    int idItem = chance.Next(0, 3);
                    Console.Write($"\n"
                   + $"|| Название: {itemsLegendary[idItem].Name} \n"
                   + $"|| Редклсть: {itemsLegendary[idItem].Rare} \n");
                    player.Inventory.Add(itemsLegendary[idItem]);
                }
                else if (chanceItem <= 5)
                {
                    int idItem = chance.Next(0, 15);
                    Console.Write($"\n"
                   + $"|| Название: {itemsRare[idItem].Name} \n"
                   + $"|| Редклсть: {itemsRare[idItem].Rare} \n");
                    player.Inventory.Add(itemsRare[idItem]);
                }
                else if (chanceItem <= 20)
                {
                    int idItem = chance.Next(0, 14);
                    Console.Write($"\n"
                   + $"|| Название: {itemsUncommon[idItem].Name} \n"
                   + $"|| Редклсть: {itemsUncommon[idItem].Rare} \n");
                    player.Inventory.Add(itemsUncommon[idItem]);
                }
                else if (chanceItem <= 90)
                {
                    int idItem = chance.Next(0, 15);
                    Console.Write($"\n"
                   + $"|| Название: {itemsCommon[idItem].Name} \n"
                   + $"|| Редклсть: {itemsCommon[idItem].Rare} \n");
                    player.Inventory.Add(itemsCommon[idItem]);
                }
                else
                    Console.WriteLine("\n Ты не получил предмет");
            }
            else
                Console.WriteLine("капец ты лох. ты здох");
        }

        static void Menu(Magician pl)
        {
            do
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine($"Информация о игроке: 1\n" +
                                  $"Экиперовка: 2\n" +
                                  $"Инвентарь: 3\n" +
                                  $"Способности: 4");
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
                        pl.ListMagicSkill();
                        break;
                }
                Console.WriteLine("для продолжения надимете любую клавишу...\n" +
                                  "для выхлода из меню нажимете Backspace...");
            } while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            try
            {
                Magician player = new Magician("Илья", 1, "огонь");
                Slime slime = new Slime("pinky", 1, 35, "red",10);
                player.AddItems(itemsCommon[10]);
                Battle(player, slime);
                Menu(player);

                Console.ReadKey();
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

