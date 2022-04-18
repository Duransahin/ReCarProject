using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FulentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.ModelYear).GreaterThan(2000);//araştır 
        }
    }
}
