using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandId = b.Id,
                                 BrandName = b.Name,
                                 ColorId = c.ColorId,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Images = context.CarImages.Where(ci => ci.CarId == c.Id).ToList()
                             };

                return filter == null ?
                    result.ToList() :
                    result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarByBrandAndColor(int brandId, int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.BrandId == brandId && c.ColorId == colorId
                             select new CarDetailDto()
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 Images = context.CarImages.Where(ci => ci.CarId == c.Id).ToList()
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailById(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where c.Id == id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandId = b.Id,
                                 BrandName = b.Name,
                                 ColorId = c.ColorId,
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Images = context.CarImages.Where(ci => ci.CarId == c.Id).ToList(),
                             };

                var carDetail = result.FirstOrDefault();

                if (carDetail.Images.Count == 0)
                {
                    carDetail.Images = new List<CarImage> { new CarImage { CarId = carDetail.Id, ImagePath = "defaultImage.jpg" } };
                }   
                return carDetail;
            }
        }
    }
}
