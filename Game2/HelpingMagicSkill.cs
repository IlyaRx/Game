using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class HelpingMagicSkill : Skill
    {
        private bool _healing;
        private bool _protection;
        private bool _gainDamage;
        private bool _gainCritChance;
        private bool _gainCritDamage;
        private int _price;

        public HelpingMagicSkill() { }

        public HelpingMagicSkill(string name, int level, string description, int price, bool healing = false, bool protection = false, bool gainDamage = false, bool gainCritChance = false, bool gainCritDamage = false) : base(name, level, description)
        {
            Healing = healing;
            Protection = protection;
            GainDamage = gainDamage;
            GainCritChance = gainCritChance;
            GainCritDamage = gainCritDamage;
            _price = price;
        }

        public bool Healing { get => _healing; set => _healing = value; }
        public bool Protection { get => _protection; set => _protection = value; }
        public bool GainDamage { get => _gainDamage; set => _gainDamage = value; }
        public bool GainCritChance { get => _gainCritChance; set => _gainCritChance = value; }
        public bool GainCritDamage { get => _gainCritDamage; set => _gainCritDamage = value; }
        public int Price { get => _price; set => _price = value; }

        public int HealingUse()
        {
            if (Healing)
            {
                InfoSkill();
                Console.WriteLine($"Вы востановили  {500 * Level} хп");
                return 500 * Level;
            }
            return 0;
        }

        public int ProtectionUse()
        {
            if (Protection)
            {
                InfoSkill();
                Console.WriteLine($"Вы увеличили могическое сопротевление на {100 * Level}");
                return 100 * Level;
            }
            return 0;
        }

        public int GainDamageUse()
        {
            if (GainDamage)
            {
                InfoSkill();
                Console.WriteLine($"Вы увеличили урон на {10 * Level}%");
                return (10 * Level) / 100;
            }
            return 1;
        }

        public int GainCritChanceUse()
        {
            if (GainCritChance)
            {
                InfoSkill();
                Console.WriteLine($"Вы увеличили шанс крита на  {Level}%");
                return Level / 100;
            }
            return 0;
        }

        public int GainCritDamageUse()
        {
            if (GainCritDamage)
            {
                InfoSkill();
                Console.WriteLine($"Вы увеличили крит урон на  {10 * Level}%");
                return (10 * Level) / 100;
            }
            return 0;
        }


        public override void InfoSkill()
        {
            base.InfoSkill();
            Console.Write((Healing ? $"|| Тип: Лечение {1000 * Level} hp\n" : ""));
            Console.Write((Protection ? $"|| Тип: Защита\n" : ""));
            Console.Write((GainDamage ? $"|| Тип: Увеличение урона\n" : ""));
            Console.Write((GainCritChance ? $"|| Тип: Увеличение крит шанса\n" : ""));
            Console.Write((GainCritDamage ? $"|| Тип: Увеличение крит урона\n" : ""));
        }
    }
}
