using BLL.Services;
using System;

namespace App
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("1. Get products by category");
                Console.WriteLine("2. Get suppliers by category");
                Console.WriteLine("3. Get products by supplier");
                Console.WriteLine("4. Get the most categorized suppliers");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                var key = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (key)
                {
                    case '1':
                        Case1();
                        Console.ReadKey();
                        break;
                    case '2':
                        Case2();
                        Console.ReadKey();
                        break;
                    case '3':
                        Case3();
                        Console.ReadKey();
                        break;
                    case '4':
                        Case4();
                        Console.ReadKey();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
        static void Case1()
        {
            var categoriesService = new CategoriesService();
            var categories = categoriesService.GetAllNames();
            var i = 0;
            foreach (var x in categories)
            {
                Console.WriteLine("{0}) {1}", i + 1, x);
                i++;
            }
            char key;
            Console.WriteLine();
            int a = 0;
            do
            {
                Console.WriteLine("\nChoose an id: ");
                key = Console.ReadKey().KeyChar;
                if (!char.IsDigit(key))
                    continue;
                else
                    a = (int)char.GetNumericValue(key);
            } while (a <= 0 || a > i);
            Console.Clear();

            var productsService = new ProductsService();
            var list = productsService.GetProductsByCategory(a);
            var category = categoriesService.GetById(a);

            Console.WriteLine("Products by " + category + " category:");
            foreach (var x in list)
                Console.WriteLine(x);
        }
        static void Case2()
        {
            var categoriesService = new CategoriesService();
            var categories = categoriesService.GetAllNames();

            var i = 0;
            foreach (var x in categories)
            {
                Console.WriteLine("{0}) {1}", i + 1, x);
                i++;
            }
            char key;
            Console.WriteLine();
            int a = 0;
            do
            {
                Console.WriteLine("\nChoose an id: ");
                key = Console.ReadKey().KeyChar;
                if (!char.IsDigit(key))
                    continue;
                else
                    a = (int)char.GetNumericValue(key);
            } while (a <= 0 || a > i);
            Console.Clear();

            var suppliersService = new SuppliersService();
            var list = suppliersService.GetSuppliersByCategory(a);
            var category = categoriesService.GetById(a);

            Console.WriteLine("Suppliers by " + category + " category:");
            foreach(var x in list)
                Console.WriteLine(x);
        }
        static void Case3()
        {
            var suppliersService = new SuppliersService();
            var suppliers = suppliersService.GetAllNames();
            var i = 0;
            foreach (var x in suppliers)
            {
                Console.WriteLine("{0}) {1}", i + 1, x);
                i++;
            }
            char key;
            Console.WriteLine();
            int a = 0;
            do
            {
                Console.WriteLine("\nChoose an id: ");
                key = Console.ReadKey().KeyChar;
                if (!char.IsDigit(key))
                    continue;
                else
                    a = (int)char.GetNumericValue(key);
            } while (a <= 0 || a > i);
            Console.Clear();

            var productsService = new ProductsService();
            var list = productsService.GetProductsBySupplier(a);
            var supplier = suppliersService.GetById(a);

            Console.WriteLine("Products by " + supplier + " supplier:");
            foreach (var x in list)
                Console.WriteLine(x);
        }
        static void Case4()
        {
            var suppliersService = new SuppliersService();
            var counter = -1;
            var list = suppliersService.GetSuppliersByMaxCategories(ref counter);
            Console.WriteLine("Supplier(s) that have " + counter.ToString() + " product categories");
            foreach (var x in list)
                Console.WriteLine(x);
        }
    }
}
