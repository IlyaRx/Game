using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.Enemys
{
    abstract class Enemy
    {
        private string _name;
        private double _hitPoints;
        private double _hitPointsMax;
        private double _level;
        private double _resistanceMagic;
        private double _resistancePhysical;
        private double _damage;
        private double _bustlevel;
        
        public Enemy() { }

        public Enemy(string name, double level, double damage, double bustlevel)
        {
            Name = name;
            HitPointsMax = 100 * level;
            HitPoints = HitPointsMax;
            Level = level;
            ResistanceMagic = 0;
            ResistancePhysical = 0;
            Damage = 15 * level + damage;
            Bustlevel = bustlevel + level / 10;
        }


        public string Name { get => _name; set => _name = value; }
        public double HitPoints { get => _hitPoints; set => _hitPoints = value; }
        public double HitPointsMax { get => _hitPointsMax; set => _hitPointsMax = value; }
        public double Level { get => _level; set => _level = value; }
        public double ResistanceMagic { get => _resistanceMagic; set => _resistanceMagic = value; }
        public double ResistancePhysical { get => _resistancePhysical; set => _resistancePhysical = value; }
        public double Damage { get => _damage; set => _damage = value; }
        public double Bustlevel { get => _bustlevel; set => _bustlevel = value; }

        public virtual void InfoEnemy()
        {
            Console.Write($"Монстр===============================\n");
            Console.Write($"|| Имя: {Name}\n");
            Console.Write($"|| Уровень: {Level}\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"|| Здоровье: {HitPoints}/{HitPointsMax}\n");
            Console.ResetColor();
            Console.Write($"|| Урон: {Damage}\n");

        }
    }
}
