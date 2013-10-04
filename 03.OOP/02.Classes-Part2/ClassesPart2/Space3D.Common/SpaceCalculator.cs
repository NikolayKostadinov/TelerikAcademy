namespace Space3D.Common
{
    using System;

    public static class SpaceCalculator
    {
        public static double CalculateDistance(Point3D firstPiont, Point3D secondPoint)
        {
            double distance = 
                Math.Sqrt(Math.Pow(firstPiont.CoordinateX - secondPoint.CoordinateX, 2) + 
                Math.Pow(firstPiont.CoordinateY - secondPoint.CoordinateY, 2) +
                Math.Pow(firstPiont.CoordinateZ - secondPoint.CoordinateZ, 2));
             
            return distance;
        }
    }
}
