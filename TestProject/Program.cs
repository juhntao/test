using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var et = new Entity
            {
                Id = 10,
                Name = "juhntao@live.com",
                CreatedOn = DateTime.Now
            };
            var forKey = new ForKey(TableType.Default,"Name",et);
            Console.WriteLine(forKey.GetPropertyValue());
            forKey.SetPropertyValue("juhntao");
            Console.WriteLine(forKey.GetPropertyValue());
            Console.ReadKey();
        }
    }
}
