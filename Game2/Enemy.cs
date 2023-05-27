﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Enemy
    {
        private string _name;
        private double _hitPoints;
        private double _hitPointsMax;
        private double _level;
        private double _resistanceMagic;
        private double _resistancePhysical;
        private double _damage;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double HitPoints
        {
            get => _hitPoints;
            set => _hitPoints = value;
        }

        public double HitPointsMax
        {
            get => _hitPointsMax;
            set => _hitPointsMax = value;
        }

        public double Level
        {
            get => _level;
            set => _level = value;
        }

        public double ResistanceMagic
        {
            get => _resistanceMagic;
            set => _resistanceMagic = value;
        }

        public double ResistancePhysical
        {
            get => _resistancePhysical;
            set => _resistancePhysical = value;
        }

        public double Damage
        {
            get => _damage;
            set => _damage = value;
        }
    }
}