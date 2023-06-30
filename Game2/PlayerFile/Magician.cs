using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    class Magician : Player
    {
        private double _mana;
        private double _manaMax;
        private string _direction;
        private List<Skill> _iseSkills = new List<Skill>
        {
            new HelpingMagicSkill("Лечебный мороз", 1, "Мог при использовании этого заклинания\n" +
                                                       "            Окружает себя прохладным ветром, который\n" +
                                                       "            замораживает раны, и боль утехает.",25 ,true),

            new AttackingMagicSkill("Ледяные стрелы", 1, "маг создаёт 5 стрел, которые самоноводяться\n" +
                                                         "          на врага.",20, 50),
            

            new HelpingMagicSkill("Лядяной щит", 1, "В мгновение ока создаётледяной прозрачный щит \n" +
                                                       "            Вокруг мага.",45 ,false,true),

            new AttackingMagicSkill("Глыба льда", 1, "Создаёт над противником ледяную глыбу и роняет на\n" +
                                                         "          на врага.",40, 80),


            new HelpingMagicSkill("Кулакит льяда", 1, "Кулаки покрываются тонким, но очень прочным\n" +
                                                       "            слоем льда.",75 ,false,false,true),

            new AttackingMagicSkill("Ледяная пушка", 1, "Создаёт пушку на плече мага и выстеливает ледяной\n" +
                                                         "          котречью во врага.",100, 100),
           

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
                                                          "         и летят в противника", 20 ,50 ),

            /////
            new HelpingMagicSkill("Кулак огненного дракона", 1 , "Кулаки и огружие покарываются огнём драконов\n" +
                                                          "         и увеличивают урон.\n", 45 ,false, false,true),

            new AttackingMagicSkill("Крылья огненного дракона", 1 , "За спиной мага появлявляется дво драконьих крыла,\n" +
                                                          "         покрытых огнём, и со взмахом поджигают противника.",40,80 ),

            /////
            new HelpingMagicSkill("Чешуя дракона", 1, "Появляется огенный нагрудник который защищает от\n" +
                                                       "             физ атак.", 75 ,false,true),

            new AttackingMagicSkill("Рёв огенного дракона", 1 , "Игрок делает глубокий вдох и извергает изо\n" +
                                                          "         рта драконье пламя.",100,100 ),

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
        internal List<Skill> IseSkills { get => _iseSkills; set => _iseSkills = value; }
        public List<Skill> FireSkills { get => _fireSkills; set => _fireSkills = value; }

        public int NumberAvailableSkills()
        {
            if (Level >= 6)
                return 8;
            else if (Level >= 4)
                return 6;
            else if (Level >= 2)
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

        public override void DeleteItems(ItemPlayer item)
        {
            base.DeleteItems(item);
            Damage += 4;
        }

        public double UsageMagicSkill()
        {
            Console.WriteLine("Какой навык: ");
            for (int i = 0; i < NumberAvailableSkills(); i++)
            {
                Console.WriteLine($"\n№{i + 1}: ");
                Console.Write(IseSkills[i].Name + $"/ Цена: {IseSkills[i].Price}");
            };
            Console.WriteLine("");
            int number = Convert.ToInt32(Console.ReadLine()) - 1;
            if (IseSkills[number] is HelpingMagicSkill helping)
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
            else if (IseSkills[number] is AttackingMagicSkill attacking)
            {
                if (Mana - attacking.Price > 0)
                {
                    Mana -= attacking.Price;
                    return attacking.MagicАttack() * FactorDamageMag;
                }
                else
                    Console.WriteLine("нехватает маны");
                return 0;
            }
            return 0;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            double manaUp = Math.Round(100 * Math.Pow(Math.E, 0.3 * (Level - 1)), 0);
            
            Console.WriteLine($"Мана: {ManaMax} ===> {manaUp}");
            ManaMax = manaUp;
            Mana = ManaMax;
        }

        public override void InfoPlayer()
        {
            base.InfoPlayer();
            Console.WriteLine($"|| Тип игрока: Маг\n"
            +$"|| Мана: {Mana}/{ManaMax}\n"
            +$"|| Спецификация: {Direction}\n"
            +"====================================\n");
        }
    }
}
