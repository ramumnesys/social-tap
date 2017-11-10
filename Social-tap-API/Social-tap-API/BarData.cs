﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialtapAPI
{
    public class BarData : IBarData
    {
        public List<string> Tags { get; set; } //saugomi hashtagai
        public double RateAvg { get; set; }  //žvaigždučių vidurkis

        public bool Comparison { get; set; }   //ar geriau įpylė visų barų palyginime

        public double BeverageAvg { get; set; } //baro vidurkis

        public  int BarUses { get; set; } //kiek kartų buvo pasinaudota programele konkrečiame bare 
        public int BeverageSum { get; set; } //kiek iš viso buvo įpilta bare

        public BarData() {
            Tags = new List<string>();
        }

    }
}
