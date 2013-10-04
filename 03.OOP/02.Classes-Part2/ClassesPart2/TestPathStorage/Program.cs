namespace TestPathStorage
{
    using System;
    using Space3D.Common;

    public class Program
    {
        public static void Main()
        {
            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(4, 5, 6);
            Point3D point3 = new Point3D(7, 8, 9);

            Path path = new Path();
            path.Add(point1);
            path.Add(point2);
            path.Add(point3);

            foreach (Point3D point in path.PointsOfPath)
            {
                Console.WriteLine(point);                
            }

            PathStorage.SavePathToFile("test.bin", path);
            Path path1 = PathStorage.LoadPathFromFile("test.bin");

            foreach (Point3D point in path1.PointsOfPath)
            {
                Console.WriteLine(point);
            }
        }
    }
}
