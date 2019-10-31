using HotChocolate.Types;
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

			descriptor.Field(t => t.AddAlbum(default!, default))
				.Argument("album", a => a.Type<NonNullType<AlbumInputType>>())
				.Argument("artistId", a => a.Type<NonNullType<IdType>>())
				.Type<NonNullType<AlbumType>>();

			descriptor.Field(t => t.AddSong(default!, default, default))
				.Argument("song", a => a.Type<NonNullType<SongInputType>>())
				.Argument("albumId", a => a.Type<NonNullType<IdType>>())
				.Argument("artistId", a => a.Type<NonNullType<IdType>>())
				.Type<NonNullType<SongType>>();
		}
	}
}
