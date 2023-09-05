using System;

namespace Game2.PlayerFile
{
    class HelpingMagicSkill : Skill
    {
        private bool _healing;
        private bool _protection;
        private bool _gainDamage;
        private bool _gainCritChance;
        private bool _gainCritDamage;

        public HelpingMagicSkill() { }

        public HelpingMagicSkill(string name,
                                 int level,
                                 string description,
                                 int price,
                                 bool healing = false,
                                 bool protection = false,
                                 bool gainDamage = false,
                                 bool gainCritChance = false,
                                 bool gainCritDamage = false) : base(name, level, description, price)
        {
            Healing = healing;
            Protection = protection;
            GainDamage = gainDamage;
            GainCritChance = gainCritChance;
            GainCritDamage = gainCritDamage;
        }

        public bool Healing { get => _healing; set => _healing = value; }
        public bool Protection { get => _protection; set => _protection = value; }
        public bool GainDamage { get => _gainDamage; set => _gainDamage = value; }
        public bool GainCritChance { get => _gainCritChance; set => _gainCritChance = value; }
        public bool GainCritDamage { get => _gainCritDamage; set => _gainCritDamage = value; }

        public int HealingUse()
        {
            if (Healing)
            {
                Console.WriteLine($"Вы востановили  {500 * Level} хп");
                return 500 * Level;
            }
            return 0;
        }

        public int ProtectionUse()
        {
            if (Protection)
            {
                Console.WriteLine($"Вы увеличили могическое сопротевление на {20 * Level}");
                return 20 * Level;
            }
            return 0;
        }

        public double GainDamageUse()
        {
            if (GainDamage)
            {
                Console.WriteLine($"Вы увеличили урон на {10 * Level}%");
                return 1 + (double)(10 * Level) / 100;
            }
            return 1;
        }

        public double GainCritChanceUse()
        {
            if (GainCritChance)
            {
                Console.WriteLine($"Вы увеличили шанс крита на  {(int)Level / (int)20 * (int)100}%");
                return ((double)Level / 20);
            }
            return 0;
        }

        public double GainCritDamageUse()
        {
            if (GainCritDamage)
            {
                Console.WriteLine($"Вы увеличили крит урон на  {10 * Level}%");
                return ((double)(10 * Level) / 100);
            }
            return 0;
        }


        public override void InfoSkill()
        {
            base.InfoSkill();
            Console.Write((Healing ? $"|| Тип: Лечение ({250 * Level} hp)\n" : ""));
            Console.Write((Protection ? $"|| Тип: Защита ({20 * Level})\n" : ""));
            Console.Write((GainDamage ? $"|| Тип: Увеличение урона ({10 * Level}%)\n" : ""));
            Console.Write((GainCritChance ? $"|| Тип: Увеличение крит шанса ({(int)Level / (int)20 * (int)100}%)\n" : ""));
            Console.Write((GainCritDamage ? $"|| Тип: Увеличение крит урона ({10 * Level}%)\n" : ""));
        }
    }
}
