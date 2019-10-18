using ResourceServer.Core.Entities;
using ResourceServer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceServer.Api
{
	public class Mutation
	{
		private readonly IRepository _repository;

		public Mutation(IRepository repository)
		{
			_repository = repository;
		}


		public ToDoItem AddToDoItem(ToDoItem input)
		{
			return _repository.Add(input);
		}

		public ToDoItem UpdateToDoItem(ToDoItem input)
		{
			return _repository.Update(input);
		}
	}
}
