namespace Space3D.Common
{
    using System;

    public struct Point3D
    {
        private static readonly Point3D point0 = new Point3D();

        static Point3D() 
        {
            point0.CoordinateX = 0;
            point0.CoordinateY = 0;
            point0.CoordinateZ = 0;
        }

        public Point3D(int coordinateX, int coordinateY, int coordinateZ)
            : this()
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.CoordinateZ = coordinateZ;
        }

        public static Point3D Point0
        {
            get
            {
                return point0;
            }
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public int CoordinateZ { get; set; }

        public override string ToString() 
        {
            return string.Format(
                "{0},{1},{2}", 
                this.CoordinateX, 
                this.CoordinateY, 
                this.CoordinateZ);
        }
    }
}
