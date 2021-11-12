using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;
using System;

namespace MathTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void BruteForceCorners()
        {
            CoordArray coordArray = new CoordArray();
            (int, int)[] expectedResults = new (int, int)[] { 
                (0, 0), 
                (0, CoordArray.Max - 1), 
                (CoordArray.Max - 1, 0), 
                (CoordArray.Max - 1, CoordArray.Max - 1) };
            foreach ((int, int) expectedResult in expectedResults)
            {
                (int, int) actualResult = coordArray.BruteForceFindIndex(expectedResult);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void BruteForceRandom()
        {
            CoordArray coordArray = new CoordArray();
            for (int i = 0; i < CoordArray.Max; i++)
            {
                Random r = new Random();
                (int, int) expectedResult = (r.Next(0, CoordArray.Max), r.Next(0, CoordArray.Max));
                (int, int) actualResult = coordArray.BruteForceFindIndex(expectedResult);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void OptimizedCorners()
        {
            CoordArray coordArray = new CoordArray();
            (int, int)[] expectedResults = new (int, int)[] { 
                (0, 0), 
                (0, CoordArray.Max - 1), 
                (CoordArray.Max - 1, 0), 
                (CoordArray.Max - 1, CoordArray.Max - 1) };
            foreach ((int, int) expectedResult in expectedResults)
            {
                (int, int) actualResult = coordArray.OptimizedFindIndex(expectedResult);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }

        [TestMethod]
        public void OptimizedRandom()
        {
            CoordArray coordArray = new CoordArray();
            for (int i = 0; i < CoordArray.Max; i++)
            {
                Random r = new Random();
                (int, int) expectedResult = (r.Next(0, CoordArray.Max), r.Next(0, CoordArray.Max));
                (int, int) actualResult = coordArray.OptimizedFindIndex(expectedResult);
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
