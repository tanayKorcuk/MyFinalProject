using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal1 _productDal;//field olsuturuyoruz injection için

        public ProductManager(IProductDal1 productdal)//constructor injection
        {
            _productDal = productdal;
        }

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)//list<Product> dan 
        {
            //   if (DateTime.Now.Hour == 1)
            //  {
            //     return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(filter), Messages.ProductsListed);
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {

            return _productDal.GetAll(p => p.CategoryId == categoryId);//categorileri gez bizim berdiğimiz categorye eşit olanları returnle



        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);//magic stringden kurtulacağız
            }


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }





    }
}




