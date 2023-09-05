using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    internal class Berserk : Player
    {
        private int _fatigue;
        private int _fatigueMax;

        public Berserk() { }

        public Berserk(string name, int level) : base(name, level)
        {
            HitPointsMax = Math.Round(550 * Math.Pow(Math.E, 0.2 * (level - 1)));
            ResistancePhysical = 5;
            Damage = 10;
            CritChance = 0.10;
            CritDamage = 0.6;
        }

        public int Fatigue { get => _fatigue; set => _fatigue = value; }
        public int FatigueMax { get => _fatigueMax; set => _fatigueMax = value; }
    }
}
