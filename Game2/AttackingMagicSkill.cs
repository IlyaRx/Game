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

        public AttackingMagicSkill(string name, int level, string description, double damage, int price) : base(name, level, description, price)
        {
            Damage = damage;
        }

        public double Damage { get => _damage; set => _damage = value; }

        public double MagicАttack()
        {
            return Damage * Level;
        }
    }
}
