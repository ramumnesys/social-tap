﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Social_tap_API.Controllers;
using SocialtapAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace STapiTests
{
    [TestClass]
    public class TestValuesController
    {
        public List<string> TagsTest = new List<string>();
        public List<string> Tags = new List<string>();
        public Dictionary<string, List<string>> barInfo = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> barInfoTests = new Dictionary<string, List<string>>();

          [TestMethod]
          public void Average_Test3()
          {
              Calculations calc = new Calculations();
              bool test;
              calc.Average(10);
              calc.Average(2);
              calc.Average(4);
              calc.Average(4);
              test = calc.Average(5);
              Assert.IsTrue(test);
          }
          [TestMethod]
          public void Average_Test1()
          {
              var calc = new Calculations();
              bool test;
              calc.Average(5);
              test = calc.Average(6);
              Assert.IsTrue(test);
          }

          [TestMethod]
          public void Average_Test2()
          {
              var calc = new Calculations();
              bool test;
              calc.Average(6);
              test = calc.Average(4);

              Assert.IsFalse(test);
          } 

        [TestMethod]
        public void HashtagsFinder_Test1()
        {
            var calc = new Calculations();
            TagsTest = calc.HashtagsFinder("");
            CollectionAssert.AreEqual(Tags, TagsTest);
        }
        [TestMethod]
        public void HashtagsFinder_Test2()
        {
            var calc = new Calculations();
            TagsTest = calc.HashtagsFinder("Ęgeras Ębaras visai");
            Tags.Add("geras");
            Tags.Add("baras");
            CollectionAssert.AreEqual(Tags, TagsTest);
        }

        [TestMethod]
        public void HashtagsFinder_Test3()
        {
            var calc = new Calculations();
            TagsTest = calc.HashtagsFinder("Ęgeras baras visai");
            Tags.Add("geras");
            Tags.Add("baras");
            CollectionAssert.AreNotEqual(Tags, TagsTest);
        }

        [TestMethod]
        public void HashtagsFinder_Test4()
        {
            var calc = new Calculations();
            TagsTest = calc.HashtagsFinder("");
            Tags.Add("geras");
            Tags.Add("baras");
            CollectionAssert.AreNotEqual(Tags, TagsTest);
        }

        [TestMethod]
        public void BarRateAverage_Test1()
        {
            var calc = new Calculations();
            var test = calc.BarRateAverage("busi3", 5);
            test = calc.BarRateAverage("busi3", 4);
            test = calc.BarRateAverage("snekutis", 4);
            test = calc.BarRateAverage("busi3", 3);
            Assert.AreEqual(test, 4);
        }
        [TestMethod]
        public void BarRateAverage_Test2()
        {
            var calc = new Calculations();
            calc.BarRateAverage("busi3", 5);
            calc.BarRateAverage("busi3", 4);
            var test2 = calc.BarRateAverage("snekutis", 4);
            calc.BarRateAverage("busi3", 3);
            Assert.AreEqual(test2, 4);
        }
        [TestMethod]
        public void BarRateAverage_Test3()
        {
            var calc = new Calculations();
            var test = calc.BarRateAverage("busi3", 5);
            calc.BarRateAverage("busi3", 4);
            calc.BarRateAverage("snekutis", 4);
            test = calc.BarRateAverage("busi3", 4);
            Assert.AreNotEqual(test, 4);
        }

        [TestMethod]
        public void BarRateAverage_Test4()
        {
            var calc = new Calculations();
            var test = calc.BarRateAverage("7fridays", 5);
            calc.BarRateAverage("7fridays", 4);
            calc.BarRateAverage("7fridays", 4);
            test = calc.BarRateAverage("7fridays", 3);
            Assert.AreEqual(test, 4);
        }

        [TestMethod] 
        public void AddBarReview_Test1 ()
        {
            var valuesController = new ValuesController();
            bool test = valuesController.AddBarReview("", "", 4, 10);
            Assert.IsFalse(test);
        }
        [TestMethod]
        public void AddBarReview_Test2 ()
        {
            var valuesController = new ValuesController();
            bool test = valuesController.AddBarReview("busi3", "", 6, 10);
            Assert.IsFalse(test);
        }
        [TestMethod]
        public void AddBarReview_Test3()
        {
            var valuesController = new ValuesController();
            bool test = valuesController.AddBarReview("busi3", "", 4, 11);
            Assert.IsFalse(test);
        }
        [TestMethod]
        public void AddBarReview_Test4()
        {
            var valuesController = new ValuesController();
            bool test = valuesController.AddBarReview("busi3", "", 4, 10);
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void AddBarReview_Test5()
        {
            var valuesController = new ValuesController();
            bool test = valuesController.AddBarReview("busi3", "", -1,6);
            Assert.IsFalse(test);
        }
        [TestMethod] 
        public void barNameAdaptation_Test1()
        {
            var calc = new Calculations();
            string barName = calc.BarNameAdaptation("Busi 3");
            Assert.AreEqual("Busi3", barName);
        }

        [TestMethod]
        public void barNameAdaptation_Test2()
        {
            var calc = new Calculations();
            string barName = calc.BarNameAdaptation("BUSI 3");
            Assert.AreEqual("Busi3", barName);
        }

        [TestMethod]
        public void barNameAdaptation_Test3()
        {
            var calc = new Calculations();
            string barName = calc.BarNameAdaptation("BUSI-3");
            Assert.AreEqual("Busi3", barName);
        }

        [TestMethod]
        public void barNameAdaptation_Test4()
        {
            var calc = new Calculations();
            string barName = calc.BarNameAdaptation("busi.3");
            Assert.AreEqual("Busi3", barName);
        }

        [TestMethod]
        public void barNameAdaptation_Test5()
        {
            var calc = new Calculations();
            string barName = calc.BarNameAdaptation("7Fridays");
            Assert.AreNotEqual("7Fridays", barName);
        }


        [TestMethod]
        public void Validation_Test1()
        {
            var calc = new Calculations();
            bool test = calc.Validation(5, 6, "");
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Validation_Test2()
        {
            var calc = new Calculations();
            bool test = calc.Validation(-2, 6, "");
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void Validation_Test3()
        {
            var calc = new Calculations();
            bool test = calc.Validation(0, 0, "a");
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void IsBarNew_Test1()
        {
            var calc = new Calculations();
            bool test = calc.IsBarNew("aaa");
            Assert.IsFalse(test);
        }

        [TestMethod]
        public void IsBarNew_Test2()
        {
            var calc = new Calculations();
            bool test = calc.IsBarNew("aaa");
            test = calc.IsBarNew("aaa");
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void BestBarRate_Test1 ()
        {
            var calc = new Calculations();
            calc.AddBarInfo("busi3", 5, 4, "");
            calc.AddBarInfo("busi3", 5, 4, "");
            string test = calc.BestBarRate();
            Assert.AreEqual("busi3", test);
        }

        [TestMethod]
        public void BestBarRate_Test2()
        {
            var calc = new Calculations();
            calc.AddBarInfo("busi3", 4, 4, "");
            calc.AddBarInfo("busi3", 4, 4, "");
            calc.AddBarInfo("snekutis", 5, 5, "");
            string test = calc.BestBarRate();
            Assert.AreEqual("snekutis", test);
        }
        [TestMethod]
        public void BestBarRate_Test3()
        {
            var calc = new Calculations();
            calc.AddBarInfo("busi3", 5, 4, "");
            calc.AddBarInfo("busi3", 5, 4, "");
            calc.AddBarInfo("snekutis", 5, 5, "");
            calc.AddBarInfo("snekutis", 5, 0, "");
            string test = calc.BestBarRate();
            Assert.AreEqual("busi3", test);
        }

    }
}
