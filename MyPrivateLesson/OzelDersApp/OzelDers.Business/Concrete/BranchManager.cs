using System;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;

namespace OzelDers.Business.Concrete
{
	public class BranchManager : IBranchService
	{
		private IBranchRepository _branchRepository;

        public BranchManager(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task CreateAsync(Branch branch)
        {
            await _branchRepository.CreateAsync(branch);
        }

        public void Delete(Branch branch)
        {
            _branchRepository.Delete(branch);
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            return await _branchRepository.GetAllAsync();
        }

        public async Task<string> GetBranchNameByUrlAsync(string url)
        {
            return await _branchRepository.GetBranchNameByUrlAsync(url);
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _branchRepository.GetByIdAsync(id);
        }

        public void Update(Branch branch)
        {
            _branchRepository.Update(branch);
        }

        public async Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus)
        {
            return await _branchRepository.GetBranchesAsync(ApprovedStatus);
        }

        public async Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus)
        {
            return await _branchRepository.GetAllBranchesFullDataAsync(ApprovedStatus);
        }

        public async Task<Branch> GetBranchFullDataAsync(int id)
        {
            return await _branchRepository.GetBranchFullDataAsync(id);
        }

        public async Task<List<Branch>> GetBranchesByTeacherAsync(int id)
        {
            return await _branchRepository.GetBranchesByTeacherAsync(id);
        }
    }
}

