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
        private static Plane PLANE = Plane.FromPoints(new Point3D(6, 4, -1), new Point3D(1, -8, 3), new Point3D(2, 1, -4));

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
        }

        public static void GenerateLog()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<Point3D> points = new List<Point3D>();

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Point3D projected = new Point3D(i, j, 0).ProjectOn(PLANE);
                    points.Add(projected);
                    stringBuilder.Append($"{projected.X}\t{projected.Y}\t{projected.Z}\n");
                }
            }

            File.WriteAllText(PATH + "test_point_cloud.txt", stringBuilder.ToString());

            Point3D centoid = new Point3D(
                points.Average(p => p.X),
                points.Average(p => p.Y),
                points.Average(p => p.Z));

            Console.WriteLine($"Centroid: {centoid}");
            Console.WriteLine($"Normal: {PLANE.Normal}");
        }

        public static void GenerateLevelingInfo()
        {
            Console.WriteLine($"Theta (rad): {GetThetaInverted(PLANE)}");
            Console.WriteLine($"Theta (deg): {GetThetaInverted(PLANE, false)}");
        }
        public static Point2D GetThetaInverted(Plane plane, bool use_radians = true)
        {
            Line3D projectX = plane.Project(new Line3D(new Point3D(0d, 0d, 0d), new Point3D(1d, 0d, 0d)));
            Line3D projectY = plane.Project(new Line3D(new Point3D(0d, 0d, 0d), new Point3D(0d, 1d, 0d)));
            double THY = -1 *MathNet.Numerics.Trig.Atan((projectX.EndPoint.Z - projectX.StartPoint.Z) / (projectX.EndPoint.X - projectX.StartPoint.X));
            if (!use_radians) THY = MathNet.Numerics.Trig.RadianToDegree(THY);
            double THX = -1 *MathNet.Numerics.Trig.Atan((projectY.EndPoint.Z - projectY.StartPoint.Z) / (projectY.EndPoint.Y - projectY.StartPoint.Y));
            if (!use_radians) THX = MathNet.Numerics.Trig.RadianToDegree(THX);
            return new Point2D(THY, THX); // Tools use THX, THY
        }
    }   
}
