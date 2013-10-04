namespace Space3D.Common
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        private readonly List<Point3D> pointsOfPath = new List<Point3D>();

        public List<Point3D> PointsOfPath
        {
            get
            {
                return this.pointsOfPath;
            }
        }

        public void Add(Point3D point)
        {
            this.PointsOfPath.Add(point);
        }
    }
}
