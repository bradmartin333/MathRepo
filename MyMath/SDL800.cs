using System;
using System.Collections.Generic;
using System.IO;

namespace MyMath
{
    public class SDL800
    {
        public SDL800()
        {
            string[] raw = File.ReadAllLines(@"S:\Rustbox\tests\files\VBD01001.XLS");
            List<List<(float, DateTime)>> list = new List<List<(float, DateTime)>>
            {
                new List<(float, DateTime)>()
            };
            foreach (string line in raw)
            {
                if (line.StartsWith("Place"))
                {
                    int count = list[^1].Count;
                    if (count > 0)
                    {
                        list.Add(new List<(float, DateTime)>());
                    }
                }
                else
                {
                    string[] cols = line.Split('\t');
                    float measurement = float.Parse(cols[3]);
                    DateTime dt = DateTime.Parse($"{cols[1]}  {cols[2]}");
                    list[^1].Add((measurement, dt));
                }
            }
        }
    }
}
