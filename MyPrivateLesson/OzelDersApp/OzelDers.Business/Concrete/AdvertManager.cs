using System;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
    public class AdvertManager : IAdvertService
    {
        private IAdvertRepository _advertRepository;

        public AdvertManager(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        public async Task CreateAsync(Advert advert)
        {
            await _advertRepository.CreateAsync(advert);
        }

        public void Delete(Advert advert)
        {
            _advertRepository.Delete(advert);
        }

        public async Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus)
        {
            return await _advertRepository.GetAdvertsFullDataAsync(id,approvedStatus);
        }

        public async Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus)
        {
            return await _advertRepository.GetAllAdvertsAsync(approvedStatus);
        }

        public async Task<List<Advert>> GetAllAsync()
        {
            return await _advertRepository.GetAllAsync();
        }

        public async Task<Advert> GetByIdAsync(int id)
        {
            return await _advertRepository.GetByIdAsync(id);
        }

        public void Update(Advert advert)
        {
            _advertRepository.Update(advert);
        }


        public async Task<int> GetByUrlAsync(string url)
        {
            return await _advertRepository.GetByUrlAsync(url);
        }

        public async Task<Advert> GetAdvertFullDataAsync(int id)
        {
            return await _advertRepository.GetAdvertFullDataAsync(id);
        }
    }
}

