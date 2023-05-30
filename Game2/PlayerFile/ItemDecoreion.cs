using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    internal class ItemDecoreion : ItemPlayer
    {
        private double _addCritChance;
        private double _addCritDamage;

        public ItemDecoreion() { }

        public ItemDecoreion(string name, string rare, double addCritChance, double addCritDamage) : base(name,rare)
        {
            AddCritChance = addCritChance;
            AddCritDamage = addCritDamage;
        }

        public double AddCritChance { get => _addCritChance; set => _addCritChance = value; }
        public double AddCritDamage { get => _addCritDamage; set => _addCritDamage = value; }
    }
}
