using ResourceServer.Core.Entities;
using ResourceServer.Core.Interfaces;

namespace ResourceServer.Api
{
	public class Query
	{
		private readonly IRepository _repository;

		public Query(IRepository repository)
		{
			_repository = repository;
		}

		public ToDoItem GetToDoItem(int id)
		{
			return _repository.GetById<ToDoItem>(id);
		}
	}
}
