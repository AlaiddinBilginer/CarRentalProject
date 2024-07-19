using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.DataResults;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper, ICarService carService)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
            _carService = carService;

        }

        public IResult Add(IFormFile file, int carId)
        {

            IResult result = BusinessRules.Run(CheckCarById(carId),CheckIfCarImageLimit(carId));

            if(result != null)
            {
                return result;
            }

            var carImage = new CarImage();
            carImage.CarId = carId;
            carImage.ImagePath = _fileHelper.Upload(file, Messages.ImagesPath);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var result = BusinessRules.Run(CheckImage(id));
            if (result != null)
            {
                return result;
            }

            var dataResult = _carImageDal.Get(c => c.Id == id);

            _fileHelper.Delete(Messages.ImagesPath + dataResult.ImagePath);
            _carImageDal.Delete(dataResult);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, int id)
        {
            var result = BusinessRules.Run(CheckImage(id));
            if (result != null)
            {
                return result;
            }
            var dataResult = _carImageDal.Get(c => c.Id == id);

            dataResult.ImagePath = _fileHelper.Update(file, Messages.ImagesPath + dataResult.ImagePath, Messages.ImagesPath);
            _carImageDal.Update(dataResult);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if(result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }

            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if(result)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.CheckIfIsCarImage);
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();

            carImage.Add(new CarImage { CarId = carId, ImagePath = "defaultImage.jpg" });

            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult CheckImage(int imageId)
        {
            var result = _carImageDal.GetAll(c => c.Id == imageId).Any();

            if(result)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.CheckIfImage);
        }

        private IResult CheckCarById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Data != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CheckIfIsCarId);
        }
    }
}
