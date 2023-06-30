using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
        private double _factorDamageMag;//множитель маглической отаки
        private double _damage;//урон   
        private double _experience;//опты
        private double _experienceMax;//максимум опыта
        private double _critChance; // крит шанс
        private double _critDamage; // крит урон
        private ItemCloth _itemPlayerCloth; // одежда защита
        private ItemWeapon _itemPlayerWeapon; // оружие дамаг
        private ItemDecoreion _itemPlayerDecoration; // украшение ку кш
        private List<ItemPlayer> _inventory = new List<ItemPlayer>(10);

        public Player() { }

        public Player(string name, int level)
        {
            Name = name;
            Level = level;
            HitPointsMax = Math.Round(1000 * Math.Pow(Math.E, 0.2 * (level - 1)));
            HitPoints = HitPointsMax;
            ResistanceMagic = 0;
            ResistancePhysical = 0;
            Damage = 5;
            Experience = 0;
            ExperienceMax = Math.Round(100 * Math.Pow(Math.E, 0.5 * (level - 1)), 0);
            CritChance = 0.05;
            CritDamage = 0.5;
            ItemPlayerCloth = null;
            ItemPlayerDecoration = null;
            ItemPlayerWeapon = null;
            FactorDamageMag = 1;

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
        internal ItemCloth ItemPlayerCloth { get => _itemPlayerCloth; set => _itemPlayerCloth = value; }
        internal ItemWeapon ItemPlayerWeapon { get => _itemPlayerWeapon; set => _itemPlayerWeapon = value; }
        internal ItemDecoreion ItemPlayerDecoration { get => _itemPlayerDecoration; set => _itemPlayerDecoration = value; }
        internal List<ItemPlayer> Inventory { get => _inventory; set => _inventory = value; }
        public double FactorDamageMag { get => _factorDamageMag; set => _factorDamageMag = value; }

        public virtual double Hit()
        {
            return Damage;
        }

        public virtual void DeleteItems(ItemPlayer item)
        {

            if (item is ItemCloth)
            {
                Inventory.Add(ItemPlayerCloth);
                ResistancePhysical = 0;
                ResistanceMagic = 0;
            }
            if (item is ItemWeapon)
            {
                Inventory.Add(ItemPlayerWeapon);
                Damage = 5;
                FactorDamageMag = 1;
            }
            if (item is ItemDecoreion)
            {
                Inventory.Add(ItemPlayerDecoration);
                CritChance = 0.05;
                CritDamage = 0.5;
            }
        }

        public virtual void AddItems(ItemPlayer item)
        {
            if (item is ItemCloth cloth)
            {
                DeleteItems(item);
                Inventory.Remove(cloth);
                if (Inventory[Inventory.Count - 1] == null)
                    Inventory.RemoveAt(Inventory.Count - 1);
                ItemPlayerCloth = cloth;
                ResistancePhysical += ItemPlayerCloth.AddResistancePhysical * Level;
                ResistanceMagic += +ItemPlayerCloth.AddResistanceMagic * Level;
            }
            if (item is ItemWeapon weapon)
            {
                DeleteItems(item);
                Inventory.Remove(weapon);
                if (Inventory[Inventory.Count - 1] == null)
                    Inventory.RemoveAt(Inventory.Count - 1);
                ItemPlayerWeapon = weapon;
                Damage += ItemPlayerWeapon.AddDamage * (Level);
                FactorDamageMag += ItemPlayerWeapon.AddDamageMag;
            }
            if (item is ItemDecoreion decoreion)
            {
                DeleteItems(item);
                Inventory.Remove(decoreion);
                if (Inventory[Inventory.Count - 1] == null)
                    Inventory.RemoveAt(Inventory.Count - 1);
                ItemPlayerDecoration = decoreion;
                CritChance += ItemPlayerDecoration.AddCritChance * Level;
                CritDamage += ItemPlayerDecoration.AddCritDamage * Level;
            }

        }

        public virtual void CheckInventory()
        {
            while (true)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.Write($"{i + 1}==============================\n"
                   + $"|| Название: {Inventory[i].Name} \n"
                   + $"|| Редклсть: {Inventory[i].Rare} \n");
                }
                Console.WriteLine($"бать предмет: #номер предмета#\n" +
                                  $"Выйте из инвенторя: *");
                string kayNum = Console.ReadLine();
                if (kayNum == "*")
                    return;
                else
                {
                    Console.Write($"\n==============================\n"
                   + $"|| Название: {Inventory[Convert.ToInt32(kayNum) - 1].Name} \n"
                   + $"|| Редклсть: {Inventory[Convert.ToInt32(kayNum) - 1].Rare} \n");
                    if (Inventory[Convert.ToInt32(kayNum) - 1] is ItemCloth cloth)
                    {
                        Console.WriteLine($"|| + физ. защите: {cloth.AddResistancePhysical * Level} \n" +
                            $"|| + маг. защите: {cloth.AddResistanceMagic * Level}");
                    }
                    if (Inventory[Convert.ToInt32(kayNum) - 1] is ItemWeapon weapon)
                    {
                        Console.WriteLine($"|| + урона: {weapon.AddDamage * Level}\n" +
                            $"|| + маг. урона: {weapon.AddDamageMag}");
                    }
                    if (Inventory[Convert.ToInt32(kayNum) - 1] is ItemDecoreion decoreion)
                    {
                        Console.WriteLine($"|| + крит. шанс {decoreion.AddCritChance + Level}\n" +
                            $"|| + крит. урон {decoreion.AddCritDamage}");
                    }
                }
                Console.WriteLine($"\n=============================\n" +
                                  $"Надеть предмет: +\n" +
                                  $"Выкинуть предмет: - \n" +
                                  $"вернуться назад: Enter\n" +
                                  $"Выйте из инвенторя: *");
                string kay = Console.ReadLine();
                if (kay == "*")
                    return;
                else if (kay == "+")
                    AddItems(Inventory[Convert.ToInt32(kayNum) - 1]);
                else
                    Inventory.RemoveAt(Convert.ToInt32(kayNum) - 1);

            }
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
            if (Experience + ex >= ExperienceMax)
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
            Console.WriteLine($"Игрок===============================\n"
                            + $"|| Имя: {Name}\n"
                            + $"|| Уровень: {Level}\n"
                            + $"|| Здоровье: {HitPoints}/{HitPointsMax}\n"
                            + $"|| Магическая защита: {ResistanceMagic}\n"
                            + $"|| Физическая защита: {ResistancePhysical}\n"
                            + $"|| Урон: {Damage}\n"
                            + $"|| Опыт: {Experience}/{ExperienceMax}\n"
                            + $"|| Крит шанс/урон: {CritChance * 100}/{CritDamage * 100}\n");

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"|| Название: {ItemPlayerCloth.Name} \n"
                            + $"|| Редклсть: {ItemPlayerCloth.Rare} \n");
            Console.WriteLine($"|| + физ. защите: {ItemPlayerCloth.AddResistancePhysical * Level} \n" 
                            + $"|| + маг. защите: {ItemPlayerCloth.AddResistanceMagic * Level}");

            Console.WriteLine($"|| Название: {ItemPlayerWeapon.Name} \n"
                            + $"|| Редклсть: {ItemPlayerWeapon.Rare} \n");
            Console.WriteLine($"|| + урона: {ItemPlayerWeapon.AddDamage * Level}\n" 
                            + $"|| + маг. урона: {ItemPlayerWeapon.AddDamageMag}");

            Console.WriteLine($"|| Название: {ItemPlayerDecoration.Name} \n"
                             + $"|| Редклсть: {ItemPlayerDecoration.Rare} \n");
            Console.WriteLine($"|| + крит. шанс {ItemPlayerDecoration.AddCritChance + Level}\n" 
                            + $"|| + крит. урон {ItemPlayerDecoration.AddCritDamage + Level}");
            Console.WriteLine("-----------------------------------------");
        }
    }
}
