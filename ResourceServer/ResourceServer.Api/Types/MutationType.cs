using HotChocolate.Types;
using ResourceServer.Api.Directives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceServer.Api.Types
{
	public class MutationType : ObjectType<Mutation>
	{
		protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
		{
			descriptor.Field(t => t.AddArtist(default!))
				.Argument("artist", a => a.Type<NonNullType<ArtistInputType>>())
				.Type<NonNullType<ArtistType>>();

			descriptor.Field(t => t.AddAlbum(default!))
				.Use<RecordUserMiddleware>()
				.Argument("album", a => a.Type<NonNullType<AlbumInputType>>())
				.Type<NonNullType<AlbumType>>();

			descriptor.Field(t => t.UpdateAlbum(default!))
				.Argument("album", a => a.Type<NonNullType<AlbumInputType>>())
				.Type<NonNullType<AlbumType>>();

			descriptor.Field(t => t.AddSong(default!))
				.Argument("song", a => a.Type<NonNullType<SongInputType>>())
				.Type<NonNullType<SongType>>();

			descriptor.Field(t => t.AddRating(default!, default!))
				.Use<RecordUserMiddleware>()
				.Argument("rating", a => a.Type<NonNullType<RatingInputType>>())
				.Type<NonNullType<AlbumType>>();
		}
	}
}
