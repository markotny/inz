using ResourceServer.Core.Entities;
using ResourceServer.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace ResourceServer.Api
{
	public class Query
	{
		private readonly IRepository _repository;

		public Query(IRepository repository)
		{
			_repository = repository;
		}

		public Album GetAlbum(Guid id)
		{
			return _repository.GetById<Album>(id);
		}

		public IEnumerable<Album> GetAlbums()
		{
			return _repository.List<Album>();
		}

		public Artist GetArtist(Guid id)
		{
			return _repository.GetById<Artist>(id);
		}

		public Song GetSong(Guid id)
		{
			return _repository.GetById<Song>(id);
		}
	}
}
