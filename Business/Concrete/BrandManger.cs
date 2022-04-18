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
    public class BrandManger : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManger(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.BrandAdded);
            }
            return new SuccesResult(Messages.CarInvalid);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccesResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccesDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetByBrandsId(int brandId)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(b => b.Id == brandId));
        }

        public IResult Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
