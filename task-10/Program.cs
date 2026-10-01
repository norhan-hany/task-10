namespace task_10
{
    using Microsoft.EntityFrameworkCore;
    using task_10.Data;
    using task_10.Models;

    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var customers = context.Customers.AsQueryable();
            var Orders = context.Orders.Where(o => o.StaffId == 3);
            var products = context.Products.Include(p => p.Category);
            var OrderStore = context.Orders.GroupBy(o => o.Store).Select(g => new
            {
                g.Key,
                OrderCount = g.Count()
            });
            var Orders2 = context.Orders.Where(o => o.ShippedDate == null);
            var customers2 = context.Customers.Include(c => c.Orders).Select(c => new
            {
                c.FirstName,
                c.LastName,
                OrderCount = c.Orders.Count()
            });
            var products2 = context.Products.Include(p => p.OrderItems).Where(p => p.OrderItems.Count() == 0);
            var products3 = context.Products.Include(p => p.Stocks).Where(p => p.Stocks.Any(s => s.Quantity < 5));
            var products4 = context.Products.First(p => p.ProductId == 1);
            var products5 = context.Products.Where(p => p.ModelYear != null);
            var products6 = context.Products.Include(p => p.OrderItems).Select(p => new
            {
                p.ProductName,
                OrderCount = p.OrderItems.Count()
            });
            var Categorys = context.Products.Where(p => p.Category.CategoryName == "Mountain Bikes").Count();
            var average = context.Products.Average(p => p.ListPrice);
            var products7 = context.Products.FirstOrDefault(p => p.ProductId == 47);
            var products8 = context.Products.Include(p => p.OrderItems).Where(p => p.OrderItems.Any(o => o.Quantity > 3));
            var staffs = context.Staffs.Include(s => s.Orders).Select(s => new
            {
                s.FirstName,
                s.LastName,
                OrderCount = s.Orders.Count()
            });
            var staffs2 = context.Staffs.Where(s => s.Active==1).Select(s => new
            {
                s.FirstName,
                s.LastName,
                s.Phone
            });
            var products9 = context.Products.Include(p => p.Category).Include(b=> b.Brand).Select(s => new
            {
                CategoryName = s.Category.CategoryName,
                BrandName = s.Brand.BrandName
            });
            var completedOrders = context.Orders.Where(o => o.OrderStatus == 4);
            var products10 = context.Products.Include(p => p.OrderItems).Select(s => new
            {
                s.ProductId,
                sum=s.OrderItems.Sum(o => o.Quantity)
            });
            //foreach (var customer in customers)
            //{
            //    Console.WriteLine($"Customer Email: {customer.Email}, Name: {customer.FirstName} {customer.LastName}");
            //}
            //foreach (var order in Orders)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}, staff ID: {order.StaffId}");
            //}
            //foreach(var product in products)
            //{ 
            //    if(product.Category !=null)
            //    Console.WriteLine($"Product Name: {product.ProductName}, Category: {product.Category.CategoryName}");
            //}
            //foreach (var store in OrderStore)
            //{
            //    Console.WriteLine($"Store ID: {store.Key}, Order Count: {store.OrderCount}");
            //}
            //foreach (var order in Orders2)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}, Shipped Date: {order.ShippedDate}");
            //}
            //foreach (var customer in customers2)
            //{
            //    Console.WriteLine($"Full Name: {customer.FirstName} {customer.LastName}, Order Count: {customer.OrderCount}");

            //}
            //foreach (var product in products2)
            //{
            //    Console.WriteLine($"Product Name: {product.ProductName}, Count: {product.OrderItems.Count()}");
            //}
            //foreach(var product in products3)
            //{
            //    Console.WriteLine($"Product Name: {product.ProductName}, Count: {product.Stocks.Count()}");
            //}
            //foreach (var item in products5)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Model Year: {item.ModelYear}");
            //}
            //foreach (var item in products6)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Order Count: {item.OrderCount}");
            //}
            //foreach (var item in staffs)
            //{
            //    Console.WriteLine($"Staff Name: {item.FirstName} {item.LastName}, Order Count: {item.OrderCount}");
            //}
            //foreach (var item in staffs2)
            //{
            //    Console.WriteLine($"Staff Name: {item.FirstName} {item.LastName}, Phone: {item.Phone}");
            //}
            //foreach (var item in products9)
            //{
            //    Console.WriteLine($"Category Name: {item.CategoryName}, Brand Name: {item.BrandName}");
            //}
            //foreach (var item in completedOrders)
            //{
            //    Console.WriteLine($"Order ID: {item.OrderId}");
            //}
            foreach (var item in products10)
            {
                Console.WriteLine($"Product ID: {item.ProductId}, Total Quantity Ordered: {item.sum}");
            }
        }
    }
}
