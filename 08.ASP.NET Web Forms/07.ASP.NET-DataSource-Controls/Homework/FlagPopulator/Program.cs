using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldWebApplication;
using System.IO;

namespace FlagPopulator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new WorldEntities())
            {
                var countries = context.Countries.ToList();
                foreach (var country in countries)
                {
                    try
                    {
                        var flag = File.ReadAllBytes("../../../../countries-list-1.2/flags/" + country.Code2 + ".png");
                        country.Flag = flag;
                    }
                    catch 
                    {
                        continue;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
