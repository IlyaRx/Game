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

        public Slime(string name, int level, double damage, string color)
        {
            Name = name;
            Level = level;
            HitPointsMax = 1000;
            HitPoints = HitPointsMax;
            ResistanceMagic = 0;
            ResistancePhysical = 0;
            Damage = damage;
            ColorSlime = color;
            
        }

        public string ColorSlime
        {
            get => _colorSlime;
            set => _colorSlime = value;
        }
   }
}
