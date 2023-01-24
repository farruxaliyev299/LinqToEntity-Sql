using LinqToHW.Models;
using System.Linq;

namespace LinqToHW;

public class Program
{
    static void Main(string[] args)
    {
        NorthwindDBContext northwindDBContext = new NorthwindDBContext();

        #region Linq To Sql

        //2
        //var orders = from o in northwindDBContext.Orders
        //             join c in northwindDBContext.Customers on o.CustomerId equals c.CustomerId
        //             join e in northwindDBContext.Employees on o.EmployeeId equals e.EmployeeId
        //             join s in northwindDBContext.Shippers on o.ShipVia equals s.ShipperId
        //             select new
        //             {
        //                 CompanyName = c.CompanyName,
        //                 EmployeeName = e.FirstName,
        //                 EmployeeSurname = e.LastName,
        //                 OrderId = o.OrderId,
        //                 OrderDate = o.OrderDate,
        //                 ShipperName = s.CompanyName
        //             };

        //foreach (var o in orders)
        //{
        //    Console.WriteLine($"\n{o.OrderId}.{o.CompanyName}\n{o.EmployeeName} {o.EmployeeSurname}\n{o.ShipperName} {o.OrderDate}\n");
        //    Console.WriteLine(new String('-',100));
        //}



        //3
        //var emps = from e in northwindDBContext.Employees
        //           select new
        //           {
        //               FirstName = e.FirstName,
        //               Lastname = e.LastName,
        //               BirthDate = e.BirthDate,
        //               Age = DateTime.Now.Year - e.BirthDate.GetValueOrDefault().Year
        //           };

        //foreach (var e in emps)
        //{
        //    Console.WriteLine($"\n{e.FirstName}.{e.Lastname}\n{e.BirthDate} {e.Age}\n");
        //    Console.WriteLine(new String('-', 100));
        //}


        //4
        //var customers = from c in northwindDBContext.Customers
        //                where c.CompanyName.ToLower().Contains("restaurant")
        //                select new
        //                {
        //                    ContactName = c.ContactName,
        //                    CompanyName = c.CompanyName
        //                };

        //foreach (var c in customers)
        //{
        //    Console.WriteLine($"\n{c.ContactName}.{c.CompanyName}\n");
        //    Console.WriteLine(new String('-', 100));
        //}


        //5
        //var categories = (from c in northwindDBContext.Categories
        //                  join p in northwindDBContext.Products on c.CategoryId equals p.CategoryId
        //                  group p by c.CategoryName into g
        //                  select new
        //                  {
        //                      CategoryName = g.Key,
        //                      Stock = g.Sum(g => g.UnitsInStock)
        //                  });


        //foreach (var ctg in categories)
        //{

        //    Console.WriteLine($"\n{ctg.CategoryName}.{ctg.Stock}\n");
        //    Console.WriteLine(new String('-', 100));
        //}


        //6
        //Product newProduct = new Product()
        //{
        //    ProductName = "Kola3",
        //    UnitPrice = 5.00M,
        //    UnitsInStock = 500,
        //    CategoryId = NameToId("Beverages")
        //};

        //northwindDBContext.Products.Add(newProduct);
        //northwindDBContext.SaveChanges();

        #endregion

        #region Linq to Entity
        //2
        //var orders = northwindDBContext.Orders
        //    .Join(northwindDBContext.Customers,
        //    o => o.CustomerId,
        //    c => c.CustomerId,
        //    (o, c) => new { o, c })
        //    .Join(northwindDBContext.Employees,
        //    o => o.o.EmployeeId,
        //    e => e.EmployeeId,
        //    (o, e) => new { o, e })
        //    .Join(northwindDBContext.Shippers,
        //    o => o.o.o.ShipVia,
        //    s => s.ShipperId,
        //    (o, s) => new
        //    {
        //        CompanyName = o.o.c.CompanyName,
        //        FirstName = o.e.FirstName,
        //        LastName = o.e.LastName,
        //        OrderId = o.o.o.OrderId,
        //        OrderDate = o.o.o.OrderDate,
        //        ShipperName = s.CompanyName
        //    }).ToList();

        //foreach (var o in orders)
        //{
        //    Console.WriteLine($"\n{o.OrderId}.{o.CompanyName}\n{o.FirstName} {o.LastName}\n{o.ShipperName} {o.OrderDate}\n");
        //    Console.WriteLine(new String('-', 100));
        //}


        //3
        //var emps = northwindDBContext.Employees
        //           .Select(e => new
        //           {
        //               FirstName = e.FirstName,
        //               Lastname = e.LastName,
        //               BirthDate = e.BirthDate,
        //               Age = DateTime.Now.Year - e.BirthDate.GetValueOrDefault().Year
        //           })
        //           .ToList();

        //foreach (var e in emps)
        //{
        //    Console.WriteLine($"\n{e.FirstName}.{e.Lastname}\n{e.BirthDate} {e.Age}\n");
        //    Console.WriteLine(new String('-', 100));
        //}


        //4
        //var customers = northwindDBContext.Customers
        //                .Where(c => c.CompanyName.ToLower().Contains("restaurant"))
        //                .Select(c => new
        //                {
        //                    CompanyName = c.CompanyName,
        //                    ContactName = c.ContactName
        //                })
        //                .ToList();

        //foreach (var c in customers)
        //{
        //    Console.WriteLine($"\n{c.ContactName}.{c.CompanyName}\n");
        //    Console.WriteLine(new String('-', 100));
        //}


        //var categories = northwindDBContext.Categories
        //                 .Join(northwindDBContext.Products,
        //                 c => c.CategoryId,
        //                 p => p.CategoryId,
        //                 (c, p) => new
        //                 {
        //                     CategoryName = c.CategoryName,
        //                     UnitsInStock = p.UnitsInStock
        //                 })
        //                 .GroupBy(g => g.CategoryName)
        //                 .Select(g => new
        //                 {
        //                     CategoryName = g.Key,
        //                     UnitsInStock = g.Sum(x => x.UnitsInStock)
        //                 });

        //foreach (var ctg in categories)
        //{

        //    Console.WriteLine($"\n{ctg.CategoryName}.{ctg.UnitsInStock}\n");
        //    Console.WriteLine(new String('-', 100));
        //}


        //Hoca dedi add le yazin ancaq
        #endregion
    }

    public static int NameToId(string name)
    {
        NorthwindDBContext northwindDBContext = new();

        return northwindDBContext.Categories.FirstOrDefault(c => c.CategoryName.ToLower() == name.ToLower()).CategoryId;
    }
}