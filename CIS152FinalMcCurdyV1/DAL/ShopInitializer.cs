using CIS152FinalMcCurdyV1.Data;
using CIS152FinalMcCurdyV1.Models;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using static NuGet.Packaging.PackagingConstants;
using CIS152FinalMcCurdyV1.Data.Enum;
using System.Data.Entity;
using CIS152FinalMcCurdyV1.Models;
using Microsoft.EntityFrameworkCore;

namespace CIS152FinalMcCurdyV1.DAL
{
    public class ShopInitializer //: System.Data.Entity.DropCreateDatabaseIfModelChanges<DrinkShopAppContext>
        //System.Data.Entity.DropCreateDatabaseIfModelChanges<System.Data.Entity.DbContext>
        //System.Data.Entity.DropCreateDatabaseIfModelChanges<DrinkShopAppContext> /*System.Data.Migrations.DropCreateDatabaseIfModelChanges<DrinkShopAppContext>*/
       // System.Data.DropCreateDatabaseIfModelChanges<DrinkShopAppContext>/*System.Data.Entity.DropCreateDatabaseIfModelChanges<DrinkShopAppContext>*/
    {
        /*protected override void Seed(DrinkShopAppContext context)
        {
            var seedDate = new DateTime();
            
            //var customer = new List<Customer>
            var customers = new List<Customer>
            {
            new Customer{FirstName="Carsons",LastName="Alexa",Email="acarson@fake.edu", Phone="222-444-5555"},
            new Customer{FirstName="Meridian",LastName="Andrea",Email="ameridian@fake.edu"},
            new Customer{FirstName="Archibalt",LastName="Arturo",Email="aarchibalt@fake.edu", Phone="222-555-8855"},
            new Customer{FirstName="Baracus",LastName="BA",Email="babaracus@fake.edu"},
            new Customer{FirstName="Yang",LastName="Ying",Email="yyang@fake.edu", Phone="222-333-4455"},
            new Customer{FirstName="Prevails",LastName="Justice",Email="jprevails@fake.edu"},
            new Customer{FirstName="Oswald",LastName="Norman",Email="greengoblin@fake.org", Phone="222-222-3535"},
            new Customer{FirstName="Twist",LastName="Oliver",Email="otwist@fake.edu"}
            };

            //customer.ForEach(c => context.Customer.Add(c));
            customers.ForEach(c => context.Customer.Add(c));
            context.SaveChanges();
            var orders = new List<Order>
            {
            new Order{OrderId=1,OrderDate=seedDate,CustomerId=1,ToDoId=101},
            new Order{OrderId=2,OrderDate=(seedDate),CustomerId=2,ToDoId=101},
            new Order{OrderId=3,OrderDate=(seedDate),CustomerId=3,ToDoId=101},
            new Order{OrderId=4,OrderDate=(seedDate),CustomerId=4,ToDoId=101},
            new Order{OrderId=5,OrderDate=(seedDate),CustomerId=5,ToDoId=101},
            new Order{OrderId=6,OrderDate=(seedDate),CustomerId=6,ToDoId=101},
            new Order{OrderId=7,OrderDate=(seedDate),CustomerId=7,ToDoId=101},
            *//*new Order { OrderId = 7, OrderDate = DateTime.Parse("2005-04-01"), CustomerId = 7, ToDoId = 101 }*//*
            };
            orders.ForEach(o => context.Order.Add(o));
            context.SaveChanges();
            var drinks = new List<Drink>
            {
            new Drink{DrinkId=101,OrderId=1,DrinkName=DrinkName.WhiteChocolateMocha, DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=102,OrderId=1,DrinkName=DrinkName.WhiteChocolateMocha, DrinkType="coffee", DrinkSize="small"},
            new Drink{DrinkId=103,OrderId=1,DrinkName=DrinkName.WhiteChocolateMocha, DrinkType="coffee", DrinkSize="large"},
            new Drink{DrinkId=104,OrderId=2,DrinkName=DrinkName.IcedTea, DrinkType="tea", DrinkSize="regular"},
            new Drink{DrinkId=105,OrderId=2,DrinkName=DrinkName.GreenTea, DrinkType="tea", DrinkSize="small"},
            new Drink{DrinkId=106,OrderId=2,DrinkName=DrinkName.ChaiTea, DrinkType="tea", DrinkSize="large"},
            new Drink{DrinkId=107,OrderId=3,DrinkName=DrinkName.VanillaItalianSoda, DrinkType="soda", DrinkSize="regular"},
            new Drink{DrinkId=108,OrderId=4,DrinkName=DrinkName.StrawberryItalianSoda, DrinkType="soda", DrinkSize="small"},
            new Drink{DrinkId=109,OrderId=4,DrinkName=DrinkName.CherryItalianSoda, DrinkType="soda", DrinkSize="large"},
            new Drink{DrinkId=110,OrderId=5,DrinkName=DrinkName.Americano, DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=111,OrderId=6,DrinkName=DrinkName.Mocha, DrinkType="coffee", DrinkSize="regular"},
            new Drink{DrinkId=112,OrderId=7,DrinkName=DrinkName.Latte, DrinkType="coffee", DrinkSize="regular"},
            };
            drinks.ForEach(d => context.Drink.Add(d));
            context.SaveChanges();
        }*/
    }
}
