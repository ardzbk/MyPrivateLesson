using System;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class ImageManager : IImageService
    {
        private IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task CreateAsync(Image image)
        {
            await _imageRepository.CreateAsync(image);
        }

        public void Delete(Image image)
        {
            _imageRepository.Delete(image);
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _imageRepository.GetAllAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _imageRepository.GetByIdAsync(id);
        }

        public void Update(Image image)
        {
            _imageRepository.Update(image);
        }
    }
}

