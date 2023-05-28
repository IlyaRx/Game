using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    abstract class Player
    {
        private string _name;//имя
        private double _hitPoints;//очки жизни
        private double _hitPointsMax;//макимум очков жищзни
        private int _level;//уровень
        private double _resistanceMagic;//магиеское сопротевление
        private double _resistancePhysical;//физическое сопротевление
        private double _damage;//урон   
        private double _experience;//опты
        private double _experienceMax;//максимум опыта
        private double _critChance; // крит шанс
        private double _critDamage; // крит урон

        public Player() { }

        public Player(string name, int level)
        {
            Name = name;
            Level = level;
            HitPointsMax = Math.Round(1000 * Math.Pow(Math.E, 0.2 * (level - 1)));
            HitPoints = HitPointsMax;
            ResistanceMagic = 0;
            ResistancePhysical = 0;
            Damage = 80;
            Experience = 0;
            ExperienceMax = Math.Round(100 * Math.Pow(Math.E, 0.5 * (level - 1)), 0);
            CritChance = 0.05;
            CritDamage = 0.5;

        }

        public string Name { get => _name; set => _name = value; }
        public double HitPoints { get => _hitPoints; set => _hitPoints = value; }
        public double HitPointsMax { get => _hitPointsMax; set => _hitPointsMax = value; }
        public int Level { get => _level; set => _level = value; }
        public double ResistanceMagic { get => _resistanceMagic; set => _resistanceMagic = value; }
        public double ResistancePhysical { get => _resistancePhysical; set => _resistancePhysical = value; }
        public double Damage { get => _damage; set => _damage = value; }
        public double Experience { get => _experience; set => _experience = value; }
        public double ExperienceMax { get => _experienceMax; set => _experienceMax = value; }
        public double CritChance { get => _critChance; set => _critChance = value; }
        public double CritDamage { get => _critDamage; set => _critDamage = value; }

        public virtual double Hit()
        {
            return Damage;
        }

        public virtual void LevelUp()
        {
            Level++;
            int pustLevel = Level - 1;
            double exUp = Math.Round(100 * Math.Pow(Math.E, 0.5 * (Level - 1)), 0);
            double hitUp = Math.Round(1000 * Math.Pow(Math.E, 0.2 * (Level - 1)));

            Console.WriteLine($"Уровень: {pustLevel} ===> {Level}");
            Console.WriteLine($"Опыт: {ExperienceMax} ===> {exUp}");
            ExperienceMax = exUp;
            Console.WriteLine($"Жизни: {HitPointsMax} ===> {hitUp}");
            HitPointsMax = hitUp;
            HitPoints = HitPointsMax;
        }

        public virtual void CheckLevel(double ex)
        {
            if(Experience + ex >= ExperienceMax)
            {
                Experience += ex;
                Experience -= ExperienceMax;
                Console.WriteLine("Повышение уровня!!!");
                LevelUp();
            }
            else
                Experience += ex;
        }

        public virtual void InfoPlayer()
        {
            Console.WriteLine($"Игрок===============================");
            Console.WriteLine($"|| Имя: {Name}");
            Console.WriteLine($"|| Уровень: {Level}");
            Console.WriteLine($"|| Здоровье: {HitPoints}/{HitPointsMax}");
            Console.WriteLine($"|| Магическая защита: {ResistanceMagic}");
            Console.WriteLine($"|| Физическая защита: {ResistancePhysical}");
            Console.WriteLine($"|| Урон: {Damage}");
            Console.WriteLine($"|| Опыт: {Experience}/{ExperienceMax}");
            Console.WriteLine($"|| Крит шанс/урон: {CritChance * 100}/{CritDamage * 100}");
        }
    }
}
