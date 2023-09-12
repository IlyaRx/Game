using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Enemys
{
    class Slime : Enemy
    {
        private string _colorSlime;

        public Slime() { }

        public Slime(string name, 
                     int level, 
                     double damage, 
                     string color, 
                     double bustlevel = 0.3) : base(name, level, damage, bustlevel)
        {
            HitPointsMax = 100 * level;
            HitPoints = HitPointsMax;
            ResistanceMagic = 5 + level * 2;
            ResistancePhysical = 5;
            ColorSlime = color;
        }

        public string ColorSlime { get => _colorSlime; set => _colorSlime = value; }

        public override void InfoEnemy()
        {
            base.InfoEnemy();
            Console.WriteLine($"|| Цвет: {ColorSlime}\n"
            +"=====================================");
        }

    }
}
