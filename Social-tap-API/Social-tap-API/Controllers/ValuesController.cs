using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using SocialtapAPI;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Social_Tap_Api;
using System.Data.SqlClient;

namespace Social_tap_API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller, IValues
    {
        public string barname = "";

        public Dictionary<string, IBarData> BarData = new Dictionary<string, IBarData>();
        public static string BestBar;
        public static double AllBarsAverage;
        public static int Uses;
        public static Statistics Stats;
        public Review Reviews = new Review();
        public Bar Bars = new Bar();
        /// Metodui paduodami 4 parametrai
        /// Patikrinama ar jie atitinka reikalavimus
        /// Suvienodinami pavadinimai
        /// Naudojant kitus metodus 
        /// į _barData Dictionary sudedamos reikšmės
        [HttpPost("AddBarReview/{barName}/{comment}/{rate}/{beverage}")]
        //rate-žvaigždutės, beverage-įpilto alaus lygis
        public bool AddBarReview(string barName, string comment, int rate, int beverage) 
        {
            
            var calc = new Calculations();
            Console.WriteLine($"POST: AddBarReview/{barName}/{comment}/{rate}/{beverage}");
            if (!calc.Validation(rate, beverage, barName))
            {
                return false;
            }
            barName = calc.BarNameAdaptation(barName);
            calc.AddReview(barName, rate, beverage);
            calc.AddBar(barName);
            //BarData = calc.AddBarInfo(barName, beverage, rate, comment);
            Stats = calc.Stats();
            
                return true;

        }
        /// Iškvietus šitą metodą
        /// Jis grąžina visą Dictionary į programą
        [HttpGet]
        [Route("GetBarData")]
        public IDictionary<string, IBarData> GetBarData()
        {
            Console.WriteLine($"GET: GetBarData/");
            Calculations calc = new Calculations();
            return calc.GetBarData();

        }
        /// Iškvietus šitą metodą 
        /// Sukuriama informacija 
        /// Apie geriausią barą 
        /// Ir bendrus skaičius
        [HttpGet]
        [Route("Stats")]
        public Statistics GetStats()
        {
            Console.WriteLine($"GET: Stats/");
            return Stats ?? new Statistics();
        }

    }
}
