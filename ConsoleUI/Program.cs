using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           //  ProductTest();

            // Console.WriteLine("Hello World!");
            //CategoryTest();-Category test çalışmıyor implemnt sonrası method blokları boş episode 9 
        }

        private static void CategoryTest()//bir türlü çalışmıyor.
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());


            foreach (var product in productManager.GetProductDetailDtos())


            {
                Console.WriteLine(product.ProductName+" / "+ product.CategoryName);
            }
        }
    }
}
