using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;

namespace IEnumerableAndIQueryable
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext.DataModel db = new DataModel())
            {
                IEnumerable<Phone> phone = db.Phones.ToList();
            }
        }
    }
}
