using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FulentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.IDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManger : ICarService
    {
        ICarDal _carDal;
        public CarManger(ICarDal carDal)  
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccesResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            if (car.CarId>0)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            _carDal.Delete(car);
            return new SuccesResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int Id)
        {
            return new SuccesDataResult<List<Car>> (_carDal.GetAll(c => c.BrandId == Id));
        }

        //public IDataResult<Car> GetByCarId(int Id)
        //{
        //    return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == Id));
        //}

        public IDataResult<List<Car>> GetByDailyPrince(decimal min, decimal max)
        {
            return new SuccesDataResult<List<Car>> (_carDal.GetAll(c => c.DailyPrice <= min && c.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            return new SuccesDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == Id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult(Messages.CarUpdated);
        }

        

        
    }
}
