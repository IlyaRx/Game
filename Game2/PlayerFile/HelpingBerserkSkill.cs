using System;

namespace Game2.PlayerFile
{
    internal class HelpingBerserkSkill : Skill
    {
        private bool _healing;
        private bool _protection;
        private bool _gainDamage;

        public HelpingBerserkSkill() { }

        public HelpingBerserkSkill(string name,
                                   int level,
                                   string description,
                                   int price,
                                   bool healing = false,
                                   bool protection = false,
                                   bool gainDamage = false) : base(name, level, description, price)
        {
            Healing = healing;
            Protection = protection;
            GainDamage = gainDamage;
        }

        public bool Healing { get => _healing; set => _healing = value; }
        public bool Protection { get => _protection; set => _protection = value; }
        public bool GainDamage { get => _gainDamage; set => _gainDamage = value; }

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
                Console.WriteLine($"Вы увеличили физическое сопротевление на {20 * Level}");
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

        public override void InfoSkill()
        {
            base.InfoSkill();
            Console.Write((Healing ? $"|| Тип: Лечение ({250 * Level} hp)\n" : ""));
            Console.Write((Protection ? $"|| Тип: Защита ({20 * Level})\n" : ""));
            Console.Write((GainDamage ? $"|| Тип: Увеличение урона ({10 * Level}%)\n" : ""));
        }
    }
}
