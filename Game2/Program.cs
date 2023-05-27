using Game2.PlayerFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Program
    {
        static void Main(string[] args)
        {
            Magician player = new Magician("Илья", 10, "лёд");
            Slime slime = new Slime("pinky", 1, 10, "red");
            do
            {
                player.UsageMagicSkill();
                player.InfoPlayer();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
