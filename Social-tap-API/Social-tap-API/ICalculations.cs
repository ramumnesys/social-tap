﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialtapAPI
{
    interface ICalculations
    {
        string BarNameAdaptation(string barName);
        double BarRateAverage(string barName, int rate);
        Boolean Average(int beverageLevel);
        List<string> HashtagsFinder(string comment);
        Boolean Validation(int rate, int beverage, string barName);

    }
}