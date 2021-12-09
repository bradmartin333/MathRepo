using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;
using System.Collections.Generic;
using System.Drawing;

namespace MathTests
{
    [TestClass]
    public class EntropyTests
    {
        private Bitmap bitmap = MyMath.Properties.Resources.cube;
        private double cubeEntropy = 6.808151301416525;

        [TestMethod]
        public void GetAllPixels()
        {
            List<double> redPixels = Entropy.DeconstructImage(bitmap);
            Assert.AreEqual(bitmap.Width * bitmap.Height, redPixels.Count);
        }

        [TestMethod]
        public void GetEntropyNuget()
        {
            List<double> redPixels = Entropy.DeconstructImage(bitmap);
            Assert.AreEqual(cubeEntropy, Entropy.NugetCalc(redPixels));
        }

        [TestMethod]
        public void GetEntropySpy()
        {
            List<double> redPixels = Entropy.DeconstructImage(bitmap);
            Assert.AreEqual(cubeEntropy, Entropy.SpyCalc(redPixels));
        }
    }
}
