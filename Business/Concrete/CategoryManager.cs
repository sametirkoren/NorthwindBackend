using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            
            _categoryDal = categoryDal;
        }


        //[CacheAspect(duration:10)]
        //[CacheRemoveAspect("ICategoryService.Get")]
        //[SecuredOperation("Category.Listt")]
        //[LogAspect(typeof(DatabaseLogger))]

        //[PerformanceAspect(5)]
        public IDataResult<List<Category>> GetList()
        {
            //Thread.Sleep(5000);
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }
    }
}
