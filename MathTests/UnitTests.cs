using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;

namespace MathTests
{
    [TestClass]
    public class UnitTests
    {
        private readonly CoordArray coordArray = new CoordArray();

        [TestMethod]
        public void BruteForceCorners()
        {
            foreach ((int, int) expectedResult in CoordArray.Corners)
                Assert.AreEqual(expectedResult, coordArray.BruteForceFindIndex(expectedResult));
        }

        [TestMethod]
        public void BruteForceSingle()
        {
            Assert.AreEqual(CoordArray.SingleIndex, coordArray.BruteForceFindIndex(CoordArray.SingleIndex));
        }

        [TestMethod]
        public void OptimizedCorners()
        {
            foreach ((int, int) expectedResult in CoordArray.Corners)
                Assert.AreEqual(expectedResult, coordArray.OptimizedFindIndex(expectedResult));
        }

        [TestMethod]
        public void OptimizedSingle()
        {
            Assert.AreEqual(CoordArray.SingleIndex, coordArray.OptimizedFindIndex(CoordArray.SingleIndex));
        }
    }
}
