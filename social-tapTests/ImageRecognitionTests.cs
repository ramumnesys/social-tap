﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace social_tap.Tests
{
    [TestClass()]
    public class ImageRecognitionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullArgument()
        {
            new ImageRecognition(null);
        }
    }
}