using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.PlayerFile
{
    abstract class ItemPlayer
    {
        private string _name;
        private string _rare; //редскость 

        public ItemPlayer() { }

        public ItemPlayer(string name, string rare)
        {
            Rare = rare;
            Name = name;
        }

        public string Rare { get => _rare; set => _rare = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
