using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Slime : Enemy
    {
        private string _colorSlime;

        public Slime() { }

        public Slime(string name, int level, double damage, string color) : base(name, level, damage)
        {
            Name = name;
            Level = level;
            HitPointsMax = 100 * level;
            HitPoints = HitPointsMax;
            ResistanceMagic = 5;
            ResistancePhysical = 5;
            Damage = damage;
            ColorSlime = color;
        }

        public string ColorSlime { get => _colorSlime; set => _colorSlime = value; }

        public override void InfoEnemy()
        {
            base.InfoEnemy();
            Console.WriteLine($"|| Цвет: {ColorSlime}");
            Console.WriteLine("=====================================");
        }

    }
}
