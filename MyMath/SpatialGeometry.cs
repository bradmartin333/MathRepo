using MathNet.Spatial.Euclidean;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyMath
{
    public static class SpatialGeometry
    {
        private static string PATH = @"C:\Repos\Rustbox\tests\files\";

        // From Rust Output
        // Normal: Vec3 { x: 0.45953159245879155, y: 0.6684095890309693, z: 0.5848583904021021 }
        private static UnitVector3D UNIT_VECTOR = UnitVector3D.Create(0.45953159245879155, 0.6684095890309693, 0.5848583904021021);

        public static void ParseLog()
        {
            string[] raw = File.ReadAllLines(PATH + "point_cloud.txt");
            List<Point3D> points = new List<Point3D>();

            foreach (string line in raw)
            {
                string[] cols = line.Split('\t');
                points.Add(new Point3D(double.Parse(cols[0]), double.Parse(cols[1]), double.Parse(cols[2])));
            }

            Point3D centoid = new Point3D(
                points.Average(p => p.X),
                points.Average(p => p.Y),
                points.Average(p => p.Z));

            Console.WriteLine(centoid.ToString());
            Console.ReadKey();
        }

        public static void GenerateLog()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Plane plane = Plane.FromPoints(new Point3D(1, 2, -2), new Point3D(3, -2, 1), new Point3D(5, 1, -4));
            List<Point3D> points = new List<Point3D>();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Point3D projected = new Point3D(i, j, 0).ProjectOn(plane);
                    points.Add(projected);
                    stringBuilder.Append($"{projected.X}\t{projected.Y}\t{projected.Z}\n");
                }
            }

            File.WriteAllText(PATH + "test_point_cloud.txt", stringBuilder.ToString());

            Point3D centoid = new Point3D(
                points.Average(p => p.X),
                points.Average(p => p.Y),
                points.Average(p => p.Z));

            Plane plane1 = new Plane(centoid, UNIT_VECTOR);

            Point3D a = new Point3D(1, 2, -2);
            Point3D b = new Point3D(3, -2, 1);
            Point3D c = new Point3D(5, 1, -4);

            Console.WriteLine(a.ProjectOn(plane1).ToString());
            Console.WriteLine(b.ProjectOn(plane1).ToString());
            Console.WriteLine(c.ProjectOn(plane1).ToString());
            Console.ReadKey();
        }
    }
}
