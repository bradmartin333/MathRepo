using System;

namespace MyMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CoordArray coordArray = new CoordArray();
        }
    }

    public class CoordArray
    {
        public readonly static int Max = 1000;
        private (int, int)[,] Arr = new (int, int)[Max, Max];
        public CoordArray()
        {
            int idx = 1;
            for (int i = 0; i < Max; i++)
            {
                for (int j = 0; j < Max; j++)
                {
                    Arr[i, j] = (i, j);
                    idx++;
                }
            }
        }

        public (int, int) BruteForceFindIndex((int, int) expectedResult)
        {
            for (int i = 0; i < Max; i++)
            {
                for (int j = 0; j < Max; j++)
                {
                    if (Arr[i, j] == expectedResult)
                        return (i, j);
                }
            }
            return (-1, -1);
        }

        public (int, int) OptimizedFindIndex((int, int) expectedResult)
        {
            int x = -1;
            int y = -1;
            int delta = int.MaxValue;
            for (int i = 0; i < Max; i++)
            {
                int testDelta = Math.Abs(Arr[i, 0].Item1 - expectedResult.Item1);
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
                int testDelta = Math.Abs(Arr[x, j].Item2 - expectedResult.Item2);
                if (testDelta < delta)
                {
                    y = j;
                    delta = testDelta;
                }
                else
                    break;
            }
            return Arr[x, y];
        }
    }
}
