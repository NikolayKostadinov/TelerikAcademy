namespace BiDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class BiDictionary<K1, K2, T>
        where K1 : IComparable<K1>
        where K2 : IComparable<K2>
    {
        private const bool IsDublicationAllawed = true;
        private MultiDictionary<Tuple<K1, K2>, T> biSearchDictionary = new MultiDictionary<Tuple<K1, K2>, T>(IsDublicationAllawed);
        private MultiDictionary<K1, T> firstKeyDictionary = new MultiDictionary<K1, T>(IsDublicationAllawed);
        private MultiDictionary<K2, T> secondKeyDictionary = new MultiDictionary<K2, T>(IsDublicationAllawed);

        public void Add(K1 firstKey, K2 seconKey, T value) 
        {
 
        }
    }
}
