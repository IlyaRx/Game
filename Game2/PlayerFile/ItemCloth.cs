using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    internal class ItemCloth : ItemPlayer
    {

        private double _addResistanceMagic;
        private double _addResistancePhysical;

        public ItemCloth() { }

        public ItemCloth(string name, string rare, double addResistanceMagic = 0, double addResistancePhysical = 0) : base(name, rare)
        {
            AddResistanceMagic = addResistanceMagic;
            AddResistancePhysical = addResistancePhysical;
        }

        public double AddResistanceMagic { get => _addResistanceMagic; set => _addResistanceMagic = value; }
        public double AddResistancePhysical { get => _addResistancePhysical; set => _addResistancePhysical = value; }
    }
}
