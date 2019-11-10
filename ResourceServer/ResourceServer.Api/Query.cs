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

		public Album? GetAlbum(Guid id)
		{
			return _repository.GetById<Album>(id);
		}

		public IEnumerable<Album> GetAlbums()
		{
			return _repository.List<Album>();
		}

		public IEnumerable<Album> SearchAlbums(string? mbid, string title, string artist)
		{
			List<Album>? results = null;
			if (!string.IsNullOrEmpty(mbid))
				results = _repository.Search<Album>(album => album.MusicBrainzId == mbid);

			return results?.Count > 0
				? results
				: _repository.Search<Album>(album =>
					album.Title.ToLower().Contains(title.ToLower()) &&
					album.AlbumArtist.Name.ToLower().Contains(artist.ToLower()));
		}

		public Artist? GetArtist(Guid id)
		{
			return _repository.GetById<Artist>(id);
		}

		public IEnumerable<Artist> SearchArtists(string? mbid, string name)
		{
			List<Artist>? results = null;
			if (!string.IsNullOrEmpty(mbid))
				results = _repository.Search<Artist>(artist => artist.MusicBrainzId == mbid);

			return results?.Count > 0
				? results
				: _repository.Search<Artist>(artist =>
					artist.Name.ToLower().Contains(name.ToLower()));
		}

		public Song? GetSong(Guid id)
		{
			return _repository.GetById<Song>(id);
		}
	}
}