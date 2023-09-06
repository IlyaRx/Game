using System;
using System.Collections.Generic;

namespace Game2.PlayerFile
{
    class Magician : Player
    {
        private double _TempMana;
        private double _mana;
        private double _manaMax;
        private string _direction;
        private List<Skill> _iseSkills = new List<Skill>
        {
            //
            new HelpingMagicSkill("Лечебный мороз", 1, "Мог при использовании этого заклинания\n" +
                                                       "            Окружает себя прохладным ветром, который\n" +
                                                       "            замораживает раны, и боль утехает.",25 ,true),

            new AttackingMagicSkill("Ледяные стрелы", 1, "маг создаёт 5 стрел, которые самоноводяться\n" +
                                                         "          на врага.",30, 50),

            //
            new HelpingMagicSkill("Лядяной щит", 1, "В мгновение ока создаётледяной прозрачный щит \n" +
                                                       "            Вокруг мага.",45 ,false,true),

            new AttackingMagicSkill("Глыба льда", 1, "Создаёт над противником ледяную глыбу и роняет на\n" +
                                                         "          на врага.",50, 80),

            //
            new HelpingMagicSkill("Кулакит льяда", 1, "Кулаки покрываются тонким, но очень прочным\n" +
                                                       "            слоем льда.",75 ,false,false,true),

            new AttackingMagicSkill("Ледяная пушка", 1, "Создаёт пушку на плече мага и выстеливает ледяной\n" +
                                                         "          котречью во врага.",110, 100),

            //
            new HelpingMagicSkill("Помощ ледяной девы", 1, "Дева одаривает мага своей силой.\n" +
                                                       "            Разум холодеет и реакция ускоряется.",900 ,false,false,false,true,true),

            new AttackingMagicSkill("Ярость ледяной девы", 1 , "Маг призвает деву, которая только взглядом\n" +
                                                          "         может зоморозить любого. Она в ярости и\n" +
                                                          "         уничтожает всё на своём пути.",500,1000 ),

        };
        private List<Skill> _fireSkills = new List<Skill> {  
            ////
            new HelpingMagicSkill("Пламя Феникса", 1, "Маг на ход покрывается слоем пламени, который\n" +
                                                       "              излечивает его раны.", 25 ,true),

            new AttackingMagicSkill("Цветы Фенекса", 1 , "Во круг мага расцветают огенные лилии\n" +
                                                          "         лепистки этих цветов оращаются.\n" +
                                                          "         и летят в противника", 30 ,50 ),

            /////
            new HelpingMagicSkill("Кулак огненного дракона", 1 , "Кулаки и огружие покарываются огнём драконов\n" +
                                                          "         и увеличивают урон.\n", 45 ,false, false,true),

            new AttackingMagicSkill("Крылья огненного дракона", 1 , "За спиной мага появлявляется дво драконьих крыла,\n" +
                                                          "         покрытых огнём, и со взмахом поджигают противника.",50,80 ),

            /////
            new HelpingMagicSkill("Чешуя дракона", 1, "Появляется огенный нагрудник который защищает от\n" +
                                                       "             физ атак.", 75 ,false,true),

            new AttackingMagicSkill("Рёв огенного дракона", 1 , "Игрок делает глубокий вдох и извергает изо\n" +
                                                          "         рта драконье пламя.",110,100 ),

            /////
            new HelpingMagicSkill("Глаза дракона", 1 , "Игрок получает зркние дракона, что помогает определить\n" +
                                                          "         слабые места противника.\n", 900,false,false,false,true,true),

            new AttackingMagicSkill("Лик огненного дракона", 1 , "Маг создаёт из огня образ дракона,\n" +
                                                          "         который атакует противника.\n",500,1000 ),

        };

        public Magician() { }

        public Magician(string name, int level, string direction) : base(name, level)
        {
            ManaMax = Math.Round(100 * Math.Pow(Math.E, 0.3 * (level - 1)), 0);
            Mana = ManaMax;
            Direction = direction;
            Damage += 4;
        }


        public double Mana { get => _mana; set => _mana = value; }
        public double ManaMax { get => _manaMax; set => _manaMax = value; }
        public string Direction { get => _direction; set => _direction = value; }
        public List<Skill> IseSkills { get => _iseSkills; private set => _iseSkills = value; }
        public List<Skill> FireSkills { get => _fireSkills; private set => _fireSkills = value; }
        private double TempMana { get => _TempMana; set => _TempMana = value; }

        public override void RemInfo()
        {
            base.RemInfo();
            TempMana = Mana;
        }

        public override void InsInfo()
        {
            base.InsInfo();
            Mana = TempMana;
        }

        private int NumberAvailableSkills()
        {
            if (Level >= 8)
                return 8;
            else if (Level >= 6)
                return 6;
            else if (Level >= 3)
                return 4;
            else
                return 2;
        }

        public void ListMagicSkill()
        {
            if (Direction == "лёд")
            {
                Console.WriteLine("список доступных навыков:");
                for (int i = 0; i < NumberAvailableSkills(); i++)
                {
                    Console.WriteLine($"\n№{i + 1}");
                    IseSkills[i].InfoSkill();
                };
            }
            else if (Direction == "огонь")
            {
                Console.WriteLine("список доступных навыков:");
                for (int i = 0; i < NumberAvailableSkills(); i++)
                {
                    Console.WriteLine($"\n№{i + 1}");
                    FireSkills[i].InfoSkill();
                };
            }
        }

        public void ListMagicSkill(bool onlyAttack)
        {
            int j = 1; // счётчик для нумирайции 
            if (onlyAttack)
            {
                if (Direction == "лёд")
                {
                    Console.WriteLine("список доступных навыков:");
                    for (int i = 0; i < NumberAvailableSkills(); i++)
                    {
                        if (IseSkills[i] is AttackingMagicSkill att)
                        {
                            Console.WriteLine($"\n№{j}");
                            att.InfoSkill();
                            j += 1;
                        }
                    };
                }
                else if (Direction == "огонь")
                {
                    Console.WriteLine("список доступных навыков:");
                    for (int i = 0; i < NumberAvailableSkills(); i++)
                    {
                        if (FireSkills[i] is AttackingMagicSkill att)
                        {
                            Console.WriteLine($"\n№{j}");
                            att.InfoSkill();
                            j += 1;
                        }
                    };
                }
            }
            else
            {
                if (Direction == "лёд")
                {
                    Console.WriteLine("список доступных навыков:");
                    for (int i = 0; i < NumberAvailableSkills(); i++)
                    {
                        if (IseSkills[i] is HelpingMagicSkill help)
                        {
                            Console.WriteLine($"\n№{j}");
                            help.InfoSkill();
                            j += 1;
                        }
                    };
                }
                else if (Direction == "огонь")
                {
                    Console.WriteLine("список доступных навыков:");
                    for (int i = 0; i < NumberAvailableSkills(); i++)
                    {
                        if (FireSkills[i] is HelpingMagicSkill help)
                        {
                            Console.WriteLine($"\n№{j}");
                            help.InfoSkill();
                            j += 1;
                        }
                    };
                }
            }
        }

        public override void DeleteItems(ItemPlayer item)
        {
            base.DeleteItems(item);
            if(item is ItemWeapon)
                Damage += 4;
        }

        public double UsageMagicSkill()
        {

            Console.WriteLine("Какой навык: ");
            ListMagicSkill();
            Console.WriteLine("");
            int number = Convert.ToInt32(Console.ReadLine()) - 1;
            if (Direction == "лёд")
            {
                if (IseSkills[number] is HelpingMagicSkill helping && number <= NumberAvailableSkills())
                {
                    if (Mana - helping.Price > 0)
                    {
                        Mana -= helping.Price;
                        HitPoints = (HitPoints + helping.HealingUse() >= HitPointsMax ? HitPointsMax : HitPoints + helping.HealingUse());
                        ResistanceMagic += helping.ProtectionUse();
                        Damage *= helping.GainDamageUse();
                        CritChance += helping.GainCritChanceUse();
                        CritDamage += helping.GainCritDamageUse();
                        helping.InfoSkill();
                        return 0;
                    }
                    else
                        Console.WriteLine("нехватает маны");
                    return 0;
                }
                else if (IseSkills[number] is AttackingMagicSkill attacking && number <= NumberAvailableSkills())
                {
                    if (Mana - attacking.Price >= 0)
                    {
                        Mana -= attacking.Price;
                        return attacking.MagicАttack() * FactorDamageMag;
                    }
                    else
                        Console.WriteLine("нехватает маны");
                    return 0;
                }
                else
                    Console.WriteLine("Вы прочитали заклинание, но ничего не произошло\nВы пропуслили ход.");
                return 0;
            }
            else
            {
                if (FireSkills[number] is HelpingMagicSkill helping && number <= NumberAvailableSkills())
                {
                    if (Mana - helping.Price > 0)
                    {
                        Mana -= helping.Price;
                        HitPoints = (HitPoints + helping.HealingUse() >= HitPointsMax ? HitPointsMax : HitPoints + helping.HealingUse());
                        ResistanceMagic += helping.ProtectionUse();
                        Damage *= helping.GainDamageUse();
                        CritChance += helping.GainCritChanceUse();
                        CritDamage += helping.GainCritDamageUse();
                        helping.InfoSkill();
                        return 0;
                    }
                    else
                        Console.WriteLine("нехватает маны");
                    return 0;
                }
                else if (FireSkills[number] is AttackingMagicSkill attacking && number <= NumberAvailableSkills())
                {
                    if (Mana - attacking.Price >= 0)
                    {
                        Mana -= attacking.Price;
                        return attacking.MagicАttack() * FactorDamageMag;
                    }
                    else
                        Console.WriteLine("нехватает маны");
                    return 0;
                }
                else
                    Console.WriteLine("Вы прочитали заклинание, но ничего не произошло\nВы пропуслили ход.");
                return 0;
            }

        }

        public void LevelUpSkils()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите один атакующий навык для прокачки");
                    ListMagicSkill(true);
                    int numberSkil = Convert.ToInt32(Console.ReadLine());
                    if (Direction == "лёд")
                    {
                        if (Level <= NumberAvailableSkills())
                        {

                            if (IseSkills[numberSkil * 2 - 1] is AttackingMagicSkill ask)
                            {
                                int firstL = ask.Level;
                                double firstD = ask.MagicАttack();
                                int firstP = ask.Price;

                                ask.Level += 1;
                                ask.Price += (int)Math.Round(ask.Price * 0.35, 0);
                                Console.WriteLine($"\nУлучшкние навыка\n" +
                                $"Уровень: {firstL} ===> {ask.Level}\n" +
                                $"Урон: {firstD} ===> {ask.MagicАttack()}\n" +
                                $"Цена: {firstP} ===> {ask.Price}");
                                return;
                            }
                            else
                                Console.WriteLine("Вы попыталисть улучшить зклининие лечебное и у вас не получилось это сделать.");
                        }
                        else
                            Console.WriteLine("Вы попыталисть улучшить зклининие высокого уровня и у вас это не получилось.");
                    }
                    if (Direction == "огонь")
                    {
                        if (Level <= NumberAvailableSkills())
                        {

                            if (FireSkills[numberSkil * 2 - 1] is AttackingMagicSkill ask)
                            {
                                int firstL = ask.Level;
                                double firstD = ask.MagicАttack();
                                int firstP = ask.Price;

                                ask.Level += 1;
                                ask.Price += (int)Math.Round(ask.Price * 0.35, 0);
                                Console.WriteLine($"Улучшкние навыка\n" +
                                $"Уровень: {firstL} ===> {ask.Level}\n" +
                                $"Урон: {firstD} ===> {ask.MagicАttack()}\n" +
                                $"Цена: {firstP} ===> {ask.Price}\n");
                                return;
                            }
                        }
                        else
                            Console.WriteLine("Вы попыталисть улучшить зклининие высокого уровня и у вас это не получилось.");
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Некоректный ввод даных. нажмите любую кдлявишк для продлжения.");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();
            double manaUp = Math.Round(100 * Math.Pow(Math.E, 0.3 * (Level - 1)), 0);

            Console.WriteLine($"Мана: {ManaMax} ===> {manaUp}\n");
            ManaMax = manaUp;
            Mana = ManaMax;
            if (Level % 2 == 0)
                LevelUpSkils();
        }

        public override void InfoPlayer()
        {
            base.InfoPlayer(); ;
            Console.Write($"|| Тип игрока: Маг\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"|| Мана: {Mana}/{ManaMax}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{(Mana <= 0 ? " !!!! Мана закончалась !!!" : "")} \n");
            Console.ResetColor();
            Console.Write($"|| Спецификация: {Direction}\n");
            Console.Write("====================================\n\n");

            Console.WriteLine("для продолжения нажмити любую клавишу...");
            Console.ReadKey();
        }
    }
}
