using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomersManger : ICustomersService
    {
        ICustomersDal _customersDal;
        public CustomersManger(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        public IResult Add(Customers customers)
        {
            return new SuccesResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customers customers)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customers>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customers>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customers customers)
        {
            throw new NotImplementedException();
        }
    }
}
