using MathNet.Numerics;
using System;

namespace MyMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoordArray coordArray = new CoordArray();
            foreach ((int, int) expectedResult in CoordArray.Corners)
                coordArray.OptimizedFindIndex(expectedResult);
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                CoordArray.SingleIndex = ((int)(CoordArray.Max * r.NextDouble()), (int)(CoordArray.Max * r.NextDouble()));
                coordArray.OptimizedFindIndex(CoordArray.SingleIndex);
            }
        }
    }

    public class CoordArray
    {
        public readonly static int Max = 1000;
        public static (int, int) SingleIndex = ((int)(Max * 0.1212), (int) (Max * 0.7231));
        public readonly static (int, int)[] Corners = new (int, int)[] {
                (0, 0),
                (0, Max - 1),
                (Max - 1, 0),
                (Max - 1, Max - 1) };

        private (double, double)[,] Arr = new (double, double)[Max, Max];

        public CoordArray()
        {
            int idx = 1;
            for (int i = 0; i < Max; i++)
            {
                for (int j = 0; j < Max; j++)
                {
                    Random r = new Random();
                    Arr[i, j] = (i + r.NextDouble(), j + r.NextDouble());
                    idx++;
                }
            }
        }

        public (int, int) BruteForceFindIndex((double, double) expectedResult)
        {
            int counter = 0;
            int x = -1;
            int y = -1;
            double delta = double.MaxValue;
            for (int i = 0; i < Max; i++)
            {
                for (int j = 0; j < Max; j++)
                {
                    double testDelta = Distance.Euclidean(
                        new double[] { Math.Floor(Arr[i, j].Item1), Math.Floor(Arr[i, j].Item2) }, 
                        new double[] { expectedResult.Item1, expectedResult.Item2});
                    if (Math.Abs(testDelta) < delta)
                    {
                        x = i;
                        y = j;
                        delta = testDelta;
                    }
                    counter++;
                }
            }
            return (x, y);
        }

        public (int, int) OptimizedFindIndex((double, double) expectedResult)
        {
            int counter = 0;
            int x = -1;
            int y = -1;
            double delta = double.MaxValue;
            for (int i = 0; i < Max; i++)
            {
                double testDelta = Math.Abs(Math.Floor(Arr[i, 0].Item1) - expectedResult.Item1);
                if (testDelta < delta)
                {
                    x = i;
                    delta = testDelta;
                }
                else
                    break;
                counter++;
            }
            delta = int.MaxValue;
            for (int j = 0; j < Max; j++)
            {
                double testDelta = Math.Abs(Math.Floor(Arr[x, j].Item2) - expectedResult.Item2);
                if (testDelta < delta)
                {
                    y = j;
                    delta = testDelta;
                }
                else
                    break;
                counter++;
            }
            Console.WriteLine($"{expectedResult,-10}\tOptimized Counter = {counter,5}\tPMax = {Math.Round(100.0 * ((double)counter / (Max * Max)), 2),5}%");
            return (x, y);
        }
    }
}
