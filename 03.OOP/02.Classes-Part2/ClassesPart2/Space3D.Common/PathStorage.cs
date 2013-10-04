namespace Space3D.Common
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePathToFile(string fileName, Path path)
        {
            using (BinaryWriter bw = 
                new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                foreach (Point3D point in path.PointsOfPath)
                {
                    bw.Write(point.CoordinateX);
                    bw.Write(point.CoordinateY);
                    bw.Write(point.CoordinateZ);
                }
            }
        }

        public static Path LoadPathFromFile(string fileName) 
        {
            int coordinateX = 0;
            int coordinateY = 0;
            int coordinateZ = 0;
            Path path = new Path();
             
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (br.PeekChar() != -1)
                {
                    coordinateX = br.ReadInt32();
                    coordinateY = br.ReadInt32();
                    coordinateZ = br.ReadInt32();
                    path.Add(
                        new Point3D(
                            coordinateX, 
                            coordinateY, 
                            coordinateZ)); 
                }
            }

            return path;
        }
    }
}
