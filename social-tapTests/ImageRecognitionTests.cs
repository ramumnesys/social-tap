﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using social_tap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_tap.Tests
{
    [TestClass()]
    public class ImageRecognitionTests
    {
        [TestMethod()]
        public void ImageRecognitionTest()
        {
            ImageRecognition imageRecognition = new ImageRecognition();
            Assert.IsNotNull(imageRecognition.GetProccessedImg());
        }
    }
}