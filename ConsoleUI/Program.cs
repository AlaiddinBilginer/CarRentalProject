using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();
            //CarTest();
            //ColorTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetById(1);
            //Console.WriteLine(result.Name);

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Name);
            //}

            //var result = brandManager.GetById(1);
            //Console.WriteLine(result.Name);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Name);
            //}

            //colorManager.Add(new Color { Name = "Mavi" });
        }
    }
}
