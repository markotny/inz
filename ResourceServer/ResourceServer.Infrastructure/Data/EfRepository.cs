using ResourceServer.Core.Interfaces;
using ResourceServer.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ResourceServer.Infrastructure.Data
{
	public class EfRepository : IRepository
	{
		private readonly AppDbContext _dbContext;

		public EfRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public T GetById<T>(Guid id) where T : BaseEntity
		{
			return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
		}

		public List<T> List<T>() where T : BaseEntity
		{
			return _dbContext.Set<T>().ToList();
		}

		public T Add<T>(T entity) where T : BaseEntity
		{
			_dbContext.Set<T>().Add(entity);
			_dbContext.SaveChanges();

			return entity;
		}

		public void Delete<T>(T entity) where T : BaseEntity
		{
			_dbContext.Set<T>().Remove(entity);
			_dbContext.SaveChanges();
		}

		public T Update<T>(T entity) where T : BaseEntity
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			_dbContext.SaveChanges();

			return entity;
		}
	}
}
