﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Customers:IEntity
    {
        
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        


        // birebir ilişki => veritabanı normalizaysonu 3N
    }
}
