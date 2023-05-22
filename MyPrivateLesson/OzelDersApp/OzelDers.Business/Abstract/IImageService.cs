using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Abstract
{
	public interface IImageService
	{
        Task CreateAsync(Image image);

        Task<Image> GetByIdAsync(int id);

        Task<List<Image>> GetAllAsync();

        void Update(Image image);

        void Delete(Image image);
    }
}

