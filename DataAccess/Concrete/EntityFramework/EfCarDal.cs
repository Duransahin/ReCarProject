using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.IDtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                           join b in context.Brands on c.BrandId equals b.Id
                           join clr in context.Colors on c.ColorId equals clr.Id
                           

                           //9. gündeki videoyu izle 
                           select new CarDetailDto
                             {
                                CarName=c.CarName,
                                BrandName= b.BrandName,
                                ColorName = clr.ColorName,
                                DailyPrice=c.DailyPrice,
                                Description=c.Description,
                                
                                
                             };
                return result.ToList();

            }
        }
        
                
        
    }
}
