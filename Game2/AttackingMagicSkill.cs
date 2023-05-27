using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class AttackingMagicSkill : Skill
    {
        private double _damage;
        private int _price;

        public AttackingMagicSkill(string name, int level, string description, double damage, int price) : base(name, level, description)
        {
            Damage = damage;
            _price = price;
        }

        public int Price { get => _price; set => _price = value; }
        public double Damage { get => _damage; set => _damage = value; }

        public double MagicАttack()
        {
            return Damage * Level;
        }
    }
}
