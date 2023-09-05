using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    internal class AttackingBerserkSkill : Skill
    {
        private double _damage;

        public AttackingBerserkSkill(string name, int level, string description, double damage, int price) : base(name, level, description, price)
        {
            Damage = damage;
        }

        public double Damage { get => _damage; set => _damage = value; }

        public double Аttack()
        {
            return Damage * Level;
        }

        public override void InfoSkill()
        {
            base.InfoSkill();
            Console.WriteLine($"|| Урон: {Аttack()}");

        }
    }
}
