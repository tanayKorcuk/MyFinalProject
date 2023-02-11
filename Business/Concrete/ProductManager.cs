using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;

using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;//field olsuturuyoruz injection için
        ICategoryService _categoryService;//Icategorydal değil!
        public ProductManager(IProductDal productdal)//constructor injection
        {
            _productDal = productdal;
            _categoryService = _categoryService;
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

        [ValidationAspect(typeof(ProductValidator))]//aspect ekledik-attribute

        public IResult Add(Product product)
        {
            // ValidationTool.Validate(new ProductValidator(), product);validationda bunu hallettik
            //business codes burda sadece iş kodları olsun spagetti olmasın diye bu tavır
            //eger mevcut kategori 15 i gectise sisteme yeni ürün eklenemez
            IResult result=BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());
           
                if (result != null)
            {
                return result;
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
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
    
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId) 
        {
           // Select count(*) from products where categoryId=1 kodunu calıstırır bu
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();

        }
        private IResult CheckIfProductNameExist(string productName)
        {
            // Select count(*) from products where categoryId=1 kodunu calıstırır bu
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();

        }
        private IResult CheckIfCategoryLimitExceded()// constructorda enjekte etmeden category servis kullanarak product manegerda örnek bir implmentasyon
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
        return new SuccessResult();
        }



    }


}




