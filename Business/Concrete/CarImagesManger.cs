using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers_FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManger : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;
        public CarImagesManger(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }
        
        public IResult Add(CarImages carImages,IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            carImages.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccesResult("Resim başarıyla yüklendi");
        }
        public IResult Update(CarImages carImages, IFormFile file)
        {
            carImages.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImages.ImagePath, PathConstants.ImagesPath);
            _carImagesDal.Update(carImages);
            return new SuccesResult();
        }
        public IResult Delete(CarImages carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImagesDal.Delete(carImage);
            return new SuccesResult(); ;
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccesDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(carId).Data);
            }
            return new SuccesDataResult<List<CarImages>>(_carImagesDal.GetAll(c =>c.CarId == carId));

        }

        public IDataResult<CarImages> GetByImageId(int imageId)
        {
            throw new NotImplementedException();
        }





        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccesResult();
        }
        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImage = new List<CarImages>();
            carImage.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccesDataResult<List<CarImages>>(carImage);
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccesResult();
            }
            return new ErrorResult();
        }

       
    }
}
