using Business.Abstract;
using Business.Constants;
using Core.Utilities.DataResults;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var existingRental = _rentalDal.Get(r => r.CarId == rental.CarId);

            if (existingRental == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.AddedRental);
            }
            else
            {
                if(existingRental.ReturnDate != null)
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.AddedRental);
                }

                return new ErrorResult(Messages.AdditionFailedRental);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IResult Deliver(int id)
        {
            var rental = _rentalDal.Get(r => r.Id == id);
            if (rental == null || rental.ReturnDate != null)
            {
                return new ErrorResult(Messages.FailedDelivery);
            }

            _rentalDal.Deliver(id);
            return new SuccessResult(Messages.DeliveredCar);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id==id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
