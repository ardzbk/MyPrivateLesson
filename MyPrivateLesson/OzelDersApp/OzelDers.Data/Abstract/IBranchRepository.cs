using System;
using OzelDers.Entity.Concrete;

namespace OzelDers.Data.Abstract
{
	public interface IBranchRepository :IGenericRepository<Branch>
	{
		Task<string> GetBranchNameByUrlAsync(string url);

        Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus);

        Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus);

        Task<Branch> GetBranchFullDataAsync(int id);

        Task<List<Branch>> GetBranchesByTeacherAsync(int id);
    }
}

