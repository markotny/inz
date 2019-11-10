using HotChocolate;
using Microsoft.AspNetCore.Http;
using ResourceServer.Core.Entities;
using ResourceServer.Core.Interfaces;
using Serilog;
using System;
using System.Security.Claims;

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
			if (album.Songs?.Count > 0)
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

		public Album AddRating(Rating rating, [State("ClaimsPrincipal")]ClaimsPrincipal claimsPrincipal)
		{
			var album = _repository.GetById<Album>(rating.AlbumId);
			var user = _repository.GetById<User>(rating.UserId);

			if (album == null)
			{
				throw new ArgumentException($"Attempted to add rating to nonexistent album! rating.AlbumId: {rating.AlbumId}");
			}

			if (user == null)
			{
				Log.Debug($"User {rating.UserId} not present in db");
				if (rating.UserId == new Guid(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier)))
				{
					user = new User
					{
						Id = rating.UserId,
						Username = claimsPrincipal.Identity.Name ?? throw new Exception("Failed to retrieve username!")
					};

					Log.Debug($"Adding user {user.Id} {user.Username} to db");

					rating.User = _repository.Add(user);
				}
				else
				{
					Log.Warning($"Attempted to add rating by other user than logged in rating userId: {rating.UserId}");
				}
			}
			album.AddRating(rating);
			_repository.Update(album);
			return album;
		}
	}
}