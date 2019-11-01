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

		public Album AddAlbum(Album album, Guid artistId)
		{
			album.AlbumArtistId = artistId;
			return _repository.Add(album);
		}

		public Song AddSong(Song song, Guid albumId, Guid artistId)
		{
			song.AlbumId = albumId;
			song.ArtistId = artistId;
			return _repository.Add(song);
		}
	}
}
