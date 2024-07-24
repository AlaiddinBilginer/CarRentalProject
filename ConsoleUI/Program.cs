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
            //UserTest();
            //CustomerTest();
            //RentalTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //var result = carManager.GetById(1);
            //Console.WriteLine(result.Name);

            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            //}

            //Car newCar = new Car() { BrandId = 3, ColorId = 4, DailyPrice = 200, ModelYear = 2017, Name = "Toyota Corolla", Description = "Corolla: Artık tüm yolculuklarınız eşsiz ve daha güçlü!" };

            //var result = carManager.Add(newCar);

            //if(result.Success)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

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

        //private static void UserTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());

        //    User newUser = new User() { FirstName = "Alaiddin", LastName = "Bilginer", Email = "alaiddin@gmail.com", Password = "123456789" };

        //    userManager.Add(newUser);
        //}

        //private static void CustomerTest()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        //    Customer newCustomer = new Customer() { UserId = 1, CompanyName = "Toyota"};

        //    customerManager.Add(newCustomer);
        //}

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            //Rental newRental = new Rental() { CarId = 2, CustomerId = 5};

            //var result = rentalManager.Add(newRental);

            //var result = rentalManager.Deliver(1);

            //if (result.Success)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }
    }
}
