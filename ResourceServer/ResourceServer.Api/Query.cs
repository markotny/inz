﻿using ResourceServer.Core.Entities;
using ResourceServer.Core.Interfaces;
using System;

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
			return _repository.GetById<Album, Guid>(id);
		}

		public Artist GetArtist(Guid id)
		{
			return _repository.GetById<Artist, Guid>(id);
		}

		public Song GetSong(Guid id)
		{
			return _repository.GetById<Song, Guid>(id);
		}
	}
}
