using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ResourceServer.Core.Interfaces
{
	public interface IRepository
	{
		T? GetById<T>(Guid id) where T : BaseEntity;
		List<T> List<T>() where T : BaseEntity;
		T Add<T>(T entity) where T : BaseEntity;
		T Update<T>(T entity) where T : BaseEntity;
		void Delete<T>(T entity) where T : BaseEntity;
		List<T> Search<T>(Expression<Func<T, bool>> filter) where T : BaseEntity;
	}
}
