using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
   public class SuccesDataResult<T>:DataResult<T>
    {
        public SuccesDataResult(T data, string massage) : base(data, true, massage)
        {

        }
        public SuccesDataResult(T data) : base(data, true)
        {

        }
        public SuccesDataResult(string massage) : base(default, true, massage)
        {

        }
        public SuccesDataResult(/*global::Entities.Concrete.Rental rental*/) : base(default, true)
        {

        }
       
    }
}
