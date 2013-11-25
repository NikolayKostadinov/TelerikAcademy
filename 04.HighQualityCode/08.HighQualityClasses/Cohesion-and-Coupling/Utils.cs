using System;

namespace CohesionAndCoupling
{
    static class Utils
    {
        public static string GetFileExtension(string fileName)
        {
            if (fileName == null || (string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(fileName)))
            {
                throw new ArgumentException("The name of the file cannot be empty!");
            }
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return "";
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (fileName == null || (string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(fileName)))
            {
                throw new ArgumentException("The name of the file cannot be empty!");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }

        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(double height, double width, double depth)
        {
            CheckIfParameterIsPositive(height, "Height");
            CheckIfParameterIsPositive(width, "Width");
            CheckIfParameterIsPositive(depth, "Depth");
            double volume = width * height * depth;
            return volume;
        }



        public static double CalcDiagonalXYZ(double height, double width, double depth)
        {
            CheckIfParameterIsPositive(height, "Height");
            CheckIfParameterIsPositive(width, "Width");
            CheckIfParameterIsPositive(depth, "Depth");
            double distance = CalcDistance3D(0, 0, 0, width, height, depth);
            return distance;
        }

        public static double CalcDiagonalXY(double height, double width)
        {
            CheckIfParameterIsPositive(height, "Height");
            CheckIfParameterIsPositive(width, "Width");
            double distance = CalcDistance2D(0, 0, width, height);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            CheckIfParameterIsPositive(width, "Height");
            CheckIfParameterIsPositive(depth, "Depth");
            double distance = CalcDistance2D(0, 0, width, depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            CheckIfParameterIsPositive(height, "Height");
            CheckIfParameterIsPositive(depth, "Depth");
            double distance = CalcDistance2D(0, 0, height, depth);
            return distance;
        }

        private static void CheckIfParameterIsPositive(double parameterValue, string parameterName)
        {
            if (parameterValue < 0)
            {
                throw new ArgumentException("{0} cannot be less then 0!", parameterName);
            }
        }
    }
}
