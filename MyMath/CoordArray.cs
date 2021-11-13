using MathNet.Numerics;
using System;

namespace MyMath
{
    public class CoordArray
    {
        public readonly static int Max = 1000;
        public static (int, int) SingleIndex = ((int)(Max * 0.1212), (int) (Max * 0.7231));
        public readonly static (int, int)[] Corners = new (int, int)[] {
                (0, 0),
                (0, Max - 1),
                (Max - 1, 0),
                (Max - 1, Max - 1) };

        private readonly (double, double)[,] Arr = new (double, double)[Max, Max];

        public CoordArray()
        {
            int idx = 1;
            for (int i = 0; i < Max; i++)
            {
                for (int j = 0; j < Max; j++)
                {
                    Random r = new Random();
                    Arr[i, j] = (i + (r.NextDouble() - 0.5), j + (r.NextDouble() - 0.5));
                    idx++;
                }
            }
        }

        public (int, int) BruteForceFindIndex((double, double) expectedResult)
        {
            int x = -1;
            int y = -1;
            double delta = double.MaxValue;
            for (int i = 0; i < Max; i++)
            {
                for (int j = 0; j < Max; j++)
                {
                    double testDelta = Distance.Euclidean(
                        new double[] { Arr[i, j].Item1, Arr[i, j].Item2 }, 
                        new double[] { expectedResult.Item1, expectedResult.Item2});
                    if (Math.Abs(testDelta) < delta)
                    {
                        x = i;
                        y = j;
                        delta = testDelta;
                    }
                }
            }
            return (x, y);
        }

        public (int, int) OptimizedFindIndex((double, double) expectedResult)
        {
            int x = -1;
            int y = -1;
            double delta = double.MaxValue;
            for (int i = 0; i < Max; i++)
            {
                double testDelta = Math.Abs(Arr[i, 0].Item1 - expectedResult.Item1);
                if (testDelta < delta)
                {
                    x = i;
                    delta = testDelta;
                }
                else
                    break;
            }
            delta = int.MaxValue;
            for (int j = 0; j < Max; j++)
            {
                double testDelta = Math.Abs(Arr[x, j].Item2 - expectedResult.Item2);
                if (testDelta < delta)
                {
                    y = j;
                    delta = testDelta;
                }
                else
                    break;
            }
            return (x, y);
        }
    }
}
