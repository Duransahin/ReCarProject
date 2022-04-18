using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Car:IEntity
    {
       
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}


/*
 Brand => ID BrandName
          1  Bmw
          2 medcedes
          3 renault


Car => Id   brandId colorID Model dailyprice descript
       1       1      1     2020 
       2       1      2     2021 
       3       2      3     2000
       4       2      4     2020
brand => ıd   branName
          1    bmw
          2    mercedes
          3   renult
 color 
 
 
 
 
 */