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

		public Artist AddArtist(Artist artist)
		{
			return _repository.Add(artist);
		}

		public Album AddAlbum(Album album)
		{
			if (album.Songs.Count > 0)
			{
				foreach (var song in album.Songs)
					song.AlbumId = album.Id;
			}
			return _repository.Add(album);
		}

		public Album UpdateAlbum(Album album)
		{
			return _repository.Update(album);
		}

		public Song AddSong(Song song)
		{
			return _repository.Add(song);
		}

		public Rating AddRating(Guid albumId, Rating rating)
		{
			var album = _repository.GetById<Album>(albumId);
			album.AddRating(rating);
			_repository.Update(album);
			return rating;
		}
	}
}
