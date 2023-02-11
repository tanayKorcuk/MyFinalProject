using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {

        
        IDataResult <List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);// T nin yerine list<Product> verdik aslında
        IDataResult<List<Product>> GetAllByCategoryId(int id);

        List<Product> GetProductsByCategoryId(int categoryId);

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetailDtos();

        IDataResult<Product> GetById(int productId);

        IResult Add(Product product);//void dödüğü için ıresult

        IResult Update(Product product);

    }
}
