using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    abstract class Skill
    {
        private string _name;
        private int _level;
        private string _description;
        private int _prise;

        public Skill() { }

        public Skill(string name, int level, string description, int price)
        {
            Name = name;
            Level = level;
            Description = description;
            Price = price;
        }

        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level; set => _level = value; }
        public string Description { get => _description; set => _description = value; }
        public int Price { get => _prise; set => _prise = value; }

        public virtual void InfoSkill()
        {
            Console.WriteLine($"{Name}--------------------------------");
            Console.WriteLine($"|| Уровень заклинания: {Level}");
            Console.WriteLine($"|| Описние: {Description}");
            Console.WriteLine($"|| Цена: {Price}");
        }
    }
}
