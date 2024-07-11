using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public void Deliver(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedRental = context.Rentals.FirstOrDefault(r => r.Id == id);
                updatedRental.ReturnDate = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
