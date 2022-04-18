using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManger : IColorService
    {
        public IResult Add(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetAll(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
