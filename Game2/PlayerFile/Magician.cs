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
                                                       "            замораживает раны, и боль утехает.",30 ,true),
            
            new HelpingMagicSkill("Лядяной щит", 2, "В мгновение ока создаётледяной прозрачный щит \n" +
                                                       "            Вокруг мага.",45 ,false,true),
            
            new HelpingMagicSkill("Кулакит льяда", 3, "Кулаки покрываются тонким, но очень прочным\n" +
                                                       "            слоем льда.",75 ,false,false,true),
            
            new HelpingMagicSkill("Помощ ледяной девы", 50, "Дева одаривает мага своей силой.\n" +
                                                       "            Разум холодеет и реакция ускоряется.",900 ,false,false,false,true,true),
        };
        private List<string> _fireSkills = new List<string> { "", "", "", "", "" };

        public Magician() { }

        public Magician(string name, int level, string direction) : base(name, level)
        {
            HitPointsMax = Math.Round(1000 * Math.Pow(Math.E, 0.2 * (level - 1)));
            HitPoints = HitPointsMax;
            ManaMax = Math.Round(100 * Math.Pow(Math.E, 0.3 * (level - 1)), 0);
            Mana = ManaMax;
            Direction = direction;
        }


        public double Mana { get => _mana; set => _mana = value; }
        public double ManaMax { get => _manaMax; set => _manaMax = value; }
        public string Direction { get => _direction; set => _direction = value; }
        internal List<Skill> IseSkills { get => _iseSkills; set => _iseSkills = value; }
        public List<string> FireSkills { get => _fireSkills; set => _fireSkills = value; }

        public int NumberAvailableSkills()
        {
            if (Level >= 6)
                return 4;
            if (Level >= 4)
                return 3;
            if (Level >= 2)
                return 2;
            else
                return 1;
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

            }
        }

        public void UsageMagicSkill()
        {
            Console.WriteLine("Какой навык: ");
            for (int i = 0; i < NumberAvailableSkills(); i++)
            {
                Console.WriteLine($"\n№{i + 1}: ");
                Console.Write(IseSkills[i].Name);
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
                }
                else
                    Console.WriteLine("нехватает маны");
            }
        }

        public override void InfoPlayer()
        {
            base.InfoPlayer();
            Console.WriteLine($"|| Тип игрока: Маг");
            Console.WriteLine($"|| Мана: {Mana}/{ManaMax}");
            Console.WriteLine($"|| Спецификация: {Direction}");
            Console.WriteLine("====================================");
        }
    }
}
