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
    public class UserManger : IUserService
    {
        IUserDal _userDal;
        public UserManger(IUserDal userDal)
        {
            _userDal = userDal;

        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult(Messages.Added);
            
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccesDataResult<User>(_userDal.Get(p => p.UserId == Id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult(Messages.Uptaded);
        }
    }
}
