﻿using System;
namespace OzelDers.Data.Abstract
{
	public interface IGenericRepository<TEntity>
	{
		Task CreateAsync(TEntity entity);
		Task<TEntity> GetByIdAsync(int id);
		Task<List<TEntity>> GetAllAsync();
		void Update(TEntity entity);
		void Delete(TEntity entity);
	}
}

