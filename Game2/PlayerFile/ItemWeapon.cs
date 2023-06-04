using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    internal class ItemWeapon : ItemPlayer
    {
        private double _addDamage;
        private double _addDamageMag;

        public ItemWeapon() { }

        public ItemWeapon(string name, string rare, double addDamage, double addDamageMag = 0) : base(name, rare)
        {
            AddDamage = addDamage;
            AddDamageMag = addDamageMag;
        }

        public double AddDamage { get => _addDamage; set => _addDamage = value; }
        public double AddDamageMag { get => _addDamageMag; set => _addDamageMag = value; }
    }
}
