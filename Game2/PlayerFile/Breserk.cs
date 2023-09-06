using System;
using System.Collections.Generic;

namespace Game2.PlayerFile
{
    internal class Berserk : Player
    {
        private double _tempFatigue; //временная усталость
        private double _fatigue; //усталость
        private double _fatigueMax;
        private List<Skill> _SkillsBerserk = new List<Skill>
        {
            new HelpingBerserkSkill("Лечебный рёв", 1, "Берсерк изаёт рёв, который\n" +
                                                       "        помогает справиться с болью\n" +
                                                       "        и остонавливает кровь.", 25, true),

            new HelpingBerserkSkill("Каменая кожа", 1, "Герой напрягая мышцы укрепляеться так,\n" +
                                                       "        что кожв становиться каменой.",30, false, true),

            new HelpingBerserkSkill("Обострение чувств", 1,"Берсерк концентрируеться на враге,\n" +
                                                           "          его реакция и сила увеличиваеться.", 35, false, false, true),

            new AttackingBerserkSkill("Смертельный выпад", 1,"Берсерк делает серию из бытрыхи незаметных\n" +
                                                             "         ударов.", 50, 50),

            new AttackingBerserkSkill("Эхо ритма", 1,"Герой начинает ходить в одном ритме\n" +
                                                     "         удара сердца, создавая множество\n" +
                                                     "         клонов. В неожиданный момент наносит удар в спину", 60, 60),

            new AttackingBerserkSkill("Ярость зверя", 1,"Глаза наливаются кровью. Противник от страха\n" +
                                                        "\tне может пошевелться. Берсерк наносит \n" +
                                                        "\tудар со всей своей силы.", 110, 110)
        };

        public Berserk() { }

        public Berserk(string name, int level) : base(name, level)
        {
            HitPointsMax = Math.Round(550 * Math.Pow(Math.E, 0.2 * (level - 1)));
            ResistancePhysical += 5;
            Damage += 7;
            CritChance += 0.05;
            CritDamage += 0.1;
            Fatigue = 0;
            FatigueMax = 100;
        }

        public double Fatigue { get => _fatigue; set => _fatigue = value; }
        public double FatigueMax { get => _fatigueMax; set => _fatigueMax = value; }
        public List<Skill> SkillsBerserk { get => _SkillsBerserk; private set => _SkillsBerserk = value; }
        private double TempFatigue { get => _tempFatigue; set => _tempFatigue = value; }

        public override void RemInfo()
        {
            base.RemInfo();
            TempFatigue = Fatigue;
        }

        public override void InsInfo()
        {
            base.InsInfo();
            Fatigue = TempFatigue;
        }


        public void ListSkill()
        {
            Console.WriteLine("список доступных навыков:");
            int i = 0;
            foreach (var skill in SkillsBerserk)
            {
                Console.WriteLine($"\n№{i + 1}");
                skill.InfoSkill();
                i++;
            }
        }

        public void ListSkill(bool onlyAttack)
        {
            int i = 1;
            if (onlyAttack)
            {
                foreach (var skill in SkillsBerserk)
                {
                    if (skill is AttackingBerserkSkill att)
                    {
                        Console.WriteLine($"\n№{i}");
                        att.InfoSkill();
                        i += 1;
                    }
                }
                return;
            }
            else
            {
                foreach (var skill in SkillsBerserk)
                {
                    if (skill is HelpingBerserkSkill help)
                    {
                        Console.WriteLine($"\n№{i}");
                        help.InfoSkill();
                        i += 1;
                    }
                }
                return;
            }
        }

        public override void DeleteItems(ItemPlayer item)
        {
            base.DeleteItems(item);
            if (item is ItemCloth)
                ResistancePhysical += 5;
            if (item is ItemWeapon)
                Damage += 7;
            if (item is ItemDecoreion)
            {
                CritChance += 0.05;
                CritDamage += 0.1;
            }
        }

        public double UsageSkill()
        {
            Console.WriteLine("Какой навык: ");
            ListSkill();
            Console.WriteLine("");
            int number = Convert.ToInt32(Console.ReadLine()) - 1;
            if (SkillsBerserk[number] is HelpingBerserkSkill helping)
            {
                if (Fatigue + helping.Price <= FatigueMax)
                {
                    Fatigue += helping.Price;
                    HitPoints = (HitPoints + helping.HealingUse() >= HitPointsMax ? HitPointsMax : HitPoints + helping.HealingUse());
                    ResistancePhysical += helping.ProtectionUse();
                    Damage *= helping.GainDamageUse();
                    helping.InfoSkill();
                    return 0;
                }
                else
                    Console.WriteLine("слишком сильно устал");
                return 0;
            }
            else if (SkillsBerserk[number] is AttackingBerserkSkill attacking)
            {
                if (Fatigue + attacking.Price <= FatigueMax)
                {
                    Fatigue += attacking.Price;
                    return attacking.Аttack() * FactorDamageMag;
                }
                else
                    Console.WriteLine("слишком сильно устал");
                return 0;
            }
            else
                Console.WriteLine("В попытке симпровизировать ничего не получилось.\nВы пропуслили ход.");
            return 0;
        }

        public void LevelUpSkils()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите один атакующий навык для прокачки");
                    ListSkill(true);
                    int numberSkil = Convert.ToInt32(Console.ReadLine());
                    if (SkillsBerserk[numberSkil + 2] is AttackingBerserkSkill ask)
                    {
                        int firstL = ask.Level;
                        double firstD = ask.Аttack();
                        int firstP = ask.Price;

                        ask.Level += 1;
                        ask.Price += (int)Math.Round(ask.Price * 0.35, 0);
                        Console.WriteLine($"\nУлучшкние навыка\n" +
                        $"Уровень: {firstL} ===> {ask.Level}\n" +
                        $"Урон: {firstD} ===> {ask.Аttack()}\n" +
                        $"Цена: {firstP} ===> {ask.Price}\n");
                        return;
                    }
                    else
                        Console.WriteLine("Вы попыталисть улучшить навык лечения и у вас не получилось это сделать.");
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Некоректный ввод даных. нажмите любую кдлявишк для продлжения.");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();
            int fatigueUp = (int)Math.Round(100 * Math.Pow(Math.E, 0.3 * (Level - 1)), 0);

            Console.WriteLine($"Усталость: {FatigueMax} ===> {fatigueUp}\n");
            FatigueMax = fatigueUp;
            FatigueMax = 0;
            if (Level % 2 == 0)
                LevelUpSkils();
        }

        public override void InfoPlayer()
        {
            base.InfoPlayer(); ;
            Console.Write($"|| Тип игрока: Берсерк\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"|| Усталость: {Fatigue}/{FatigueMax}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{(Fatigue >= FatigueMax ? " !!!! Ты устал !!!" : "")} \n");
            Console.ResetColor();
            Console.Write("====================================\n\n");

            Console.WriteLine("для продолжения нажмити любую клавишу...");
            Console.ReadKey();
        }
    }
}