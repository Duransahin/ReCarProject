using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class RentalManger : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManger(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(p => p.CustomersId == rental.CustomersId);
            _rentalDal.Add(rental);
            return new SuccesResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.Deleted);

        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccesDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId));

            //return new SuccesDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId));
        }

        public IResult ToolDelivery(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.Uptaded);
        }
    }
}
