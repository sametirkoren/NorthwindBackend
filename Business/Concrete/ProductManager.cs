using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

     
        [ValidationAspect(typeof(ProductValidator))]
        IResult IProductService.Add(Product product)
        {
           
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        IResult IProductService.Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        IDataResult<Product> IProductService.GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        IDataResult<List<Product>> IProductService.GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());

        }

        IDataResult<List<Product>> IProductService.GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p=>p.CategoryId == categoryId).ToList());

        }

        IResult IProductService.Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
