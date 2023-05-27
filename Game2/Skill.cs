using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Skill
    {
        private string _name;
        private int _level;
        private string _description;

        public Skill() { }
        
        public Skill(string name, int level, string description)
        {
            Name = name;
            Level = level;
            Description = description;
        }

        public string Name { get => _name; set => _name = value; }
        public int Level { get => _level; set => _level = value; }
        public string Description { get => _description; set => _description = value; }
        
        public virtual void InfoSkill()
        {
            Console.WriteLine($"{Name}--------------------------------");
            Console.WriteLine($"|| Уровень заклинания: {Level}");
            Console.WriteLine($"|| Описние: {Description}");
        }
    }
}
