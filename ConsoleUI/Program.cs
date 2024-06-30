using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " --- Model Yılı: " + car.ModelYear);
            }

            carManager.Add(new Car { Id = 10, BrandId = 2, ColorId = 5, DailyPrice = 750, Description = "Station wagon, geniş bagaj, lüks donanım", ModelYear = 2022 });
            Console.WriteLine("---Added Car---");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " --- Model Yılı: " + car.ModelYear);
            }

            carManager.Delete(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, Description = "Sedan, manuel vites, düşük kilometre", ModelYear = 2015 });
            Console.WriteLine("---Deleted Car---");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " --- Model Yılı: " + car.ModelYear);
            }

            Console.WriteLine("---Get By Id---");
            Console.WriteLine(carManager.GetById(2).Description);

            Console.WriteLine("---Updated Car---");
            carManager.Update(new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 600, Description = "Car updated", ModelYear = 2018 });
            Console.WriteLine(carManager.GetById(2).Description);
        }
    }
}
