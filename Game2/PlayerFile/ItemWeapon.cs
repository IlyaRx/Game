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

        public ItemWeapon() { }

        public ItemWeapon(string name, string rare, double addDamage) : base(name, rare)
        {
            AddDamage = addDamage;
        }

        public double AddDamage { get => _addDamage; set => _addDamage = value; }
    }
}
