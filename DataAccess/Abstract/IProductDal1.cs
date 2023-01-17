﻿using DataAccess.DataAccess.Core;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IProductDal1:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();




    }
}
