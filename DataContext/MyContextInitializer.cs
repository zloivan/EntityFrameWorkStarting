using System.Collections.Generic;
using System.Data.Entity;

namespace DataContext
{
    class MyContextInitializer : DropCreateDatabaseAlways<DataModel>
    {
        protected override void Seed(DataModel context)
        {
            Company c1 = new Company {Name="Samsung" };
            Company c2 = new Company {Name="Microsoft" };
            Company c3 = new Company { Name = "Apple" };

            context.Companies.Add(c1);
            context.Companies.Add(c2);
            context.Companies.Add(c3);
            context.SaveChanges();
            Phone p1 = new Phone {Name="Samsung Galaxy S5",Price=20000,Company=c1 };
            Phone p2 = new Phone {Name="Samsung Galaxy S4",Price=15000,Company=c1 };
            Phone p3 = new Phone { Name = "Nokia Lumia 930", Price = 10000, Company = c2 };
            Phone p4 = new Phone { Name = "Nokia Lumia 830", Price = 8000, Company = c2 };
            Phone p5 = new Phone { Name = "IPhone 7s", Price = 25000, Company = c3 };
            Phone p6 = new Phone { Name = "IPhone 7", Price = 20000, Company = c3 };

            context.Phones.AddRange(new List<Phone> {p1,p2,p3,p4,p5,p6 });
            context.SaveChanges();
            
        }
    }
}