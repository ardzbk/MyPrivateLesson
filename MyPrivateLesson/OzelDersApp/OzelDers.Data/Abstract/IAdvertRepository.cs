using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
	public interface IAdvertRepository : IGenericRepository<Advert>
	{
        Task<List<Advert>> GetAdvertsFullDataAsync(string id, bool approvedStatus);
        Task<List<Advert>> GetAllAdvertsAsync(bool approvedStatus);
        Task<int> GetByUrlAsync(string url);
        Task<Advert> GetAdvertFullDataAsync(int id);
    }
}

