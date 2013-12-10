using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Phonebook
{
    class PhoneBook
    {
        private MultiDictionary<string, PhoneEntry> firstNames;
        private MultiDictionary<string, PhoneEntry> middleNames;
        private MultiDictionary<string, PhoneEntry> lastNames;
        private MultiDictionary<string, PhoneEntry> towns;


        public PhoneBook(List<PhoneEntry> entries)
        {
            this.firstNames = new MultiDictionary<string, PhoneEntry>(true);
            this.middleNames = new MultiDictionary<string, PhoneEntry>(true);
            this.lastNames = new MultiDictionary<string, PhoneEntry>(true);
            this.towns = new MultiDictionary<string, PhoneEntry>(true);

            foreach (var entry in entries)
            {
                this.firstNames.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.FirstName, new PhoneEntry[] { entry }));
                this.middleNames.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.MiddleName, new PhoneEntry[] { entry }));
                this.lastNames.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.LastName, new PhoneEntry[] { entry }));
                this.towns.Add(new KeyValuePair<string,
                    ICollection<PhoneEntry>>(entry.Town, new PhoneEntry[] { entry }));
            }

        }

        public List<PhoneEntry> Find(string name)
        {
            List<PhoneEntry> foundEntries = new List<PhoneEntry>();

            foundEntries.AddRange(firstNames[name]);
            foundEntries.AddRange(middleNames[name]);
            foundEntries.AddRange(lastNames[name]);

            return foundEntries;
        }

        public List<PhoneEntry> Find(string name, string town)
        {
            List<PhoneEntry> foundEntries = new List<PhoneEntry>();

            ICollection<PhoneEntry> entry = firstNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = middleNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            entry = lastNames[name];
            foundEntries.AddRange(entry.Where(x => x.Town == town));

            return foundEntries;
        }
    }
}
