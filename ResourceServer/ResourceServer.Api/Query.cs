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
			return _repository.GetById<ToDoItem, int>(id);
		}

		public Album GetAlbum(string id)
		{
			return _repository.GetById<Album, string>(id);
		}

		public Artist GetArtist(string id)
		{
			return _repository.GetById<Artist, string>(id);
		}

		public Song GetSong(string id)
		{
			return _repository.GetById<Song, string>(id);
		}
	}
}
