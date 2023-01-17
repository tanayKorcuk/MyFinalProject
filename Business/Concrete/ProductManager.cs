using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal1 _productDal;//class objesini oluşturma gereksinimi duydu
       
        public ProductManager( IProductDal1 productdal)
        {
            _productDal = productdal;
        }
        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductDetails(int id)
        {

            return _productDal.GetAll(p => p.CategoryId == id);//categorileri gez bizim berdiğimiz categorye eşit olanları returnle
            
            
            
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            return _productDal.GetProductDetails();
        }
    }



}
