﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class CarImages: IEntity
    {
        public int ImagesId { get; set; }
        public int  CarId { get; set; }
        public string ImagePath { get; set; }//ImagePath 
        public DateTime Date { get; set; }

    }
}
