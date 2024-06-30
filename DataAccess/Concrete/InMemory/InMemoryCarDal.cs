using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, Description = "Sedan, manuel vites, düşük kilometre", ModelYear = 2015},
                new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 600, Description = "SUV, otomatik vites, yüksek performans", ModelYear = 2018},
                new Car { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 450, Description = "Hatchback, manuel vites, ekonomik", ModelYear = 2016},
                new Car { Id = 4, BrandId = 1, ColorId = 4, DailyPrice = 700, Description = "Coupe, spor araç, yüksek performans", ModelYear = 2019},
                new Car { Id = 5, BrandId = 4, ColorId = 5, DailyPrice = 550, Description = "Station wagon, geniş bagaj, aile aracı", ModelYear = 2017},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car car = _cars.SingleOrDefault(c => c.Id == id);
            return car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c =>  c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
