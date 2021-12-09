using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyMath
{
    public class Entropy
    {
        public static List<double> DeconstructImage(Bitmap bitmap)
        {
            List<double> redPixels = new List<double>();
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    redPixels.Add(bitmap.GetPixel(i, j).R);
                }
            }
            return redPixels;
        }

        public static double NugetCalc(List<double> redPixels)
        {
            return MathNet.Numerics.Statistics.Statistics.Entropy(redPixels);
        }

        public static double SpyCalc(List<double> redPixels)
        {
			Dictionary<double, double> dictionary = new Dictionary<double, double>();
			int num = 0;
			foreach (double num2 in redPixels)
			{
				if (double.IsNaN(num2))
				{
					return double.NaN;
				}
				double num3;
				if (dictionary.TryGetValue(num2, out num3))
				{
					num3 = (dictionary[num2] = num3 + 1.0);
				}
				else
				{
					dictionary.Add(num2, 1.0);
				}
				num++;
			}
			double num4 = 0.0;
			foreach (KeyValuePair<double, double> keyValuePair in dictionary)
			{
				double num5 = keyValuePair.Value / (double)num;
				num4 += num5 * Math.Log(num5, 2.0);
			}
			return -num4;
		}
    }
}
