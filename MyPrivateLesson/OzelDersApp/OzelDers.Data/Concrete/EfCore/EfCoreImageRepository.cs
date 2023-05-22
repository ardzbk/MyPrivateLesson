using System;
using Microsoft.EntityFrameworkCore;
using OzelDers.Data.Abstract;
using OzelDers.Data.Concrete.EfCore.Context;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Concrete.EfCore
{
    public class EfCoreImageRepository : EfCoreGenericRepository<Image>, IImageRepository
    {
        public EfCoreImageRepository(PrivateLessonContext _appContext) : base(_appContext)
        {
        }
        PrivateLessonContext AppContext
        {
            get { return _dbContext as PrivateLessonContext; }
        }
    }
}

