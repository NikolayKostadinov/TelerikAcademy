namespace GenericList.Common
{
    using System;

    public static class GenerikListHelper
    {
        public static T1 Min<T1>(GenericList<T1> gl)
            where T1 : IComparable
        {
            T1 min;
            min = gl[0];

            for (int i = 1; i < gl.Lenght; i++)
            {
                if (gl[i].CompareTo(min) < 0)
                {
                    min = gl[i];
                }
            }

            return min;
        }

        public static T1 Max<T1>(GenericList<T1> gl)
            where T1 : IComparable
        {
            T1 max;
            max = gl[0];

            for (int i = 1; i < gl.Lenght; i++)
            {
                if (gl[i].CompareTo(max) > 0)
                {
                    max = gl[i];
                }
            }

            return max;
        }
    }
}
