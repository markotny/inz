using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceServer.Api.Types
{
	public class QueryType : ObjectType<Query>
	{
		protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
		{

			descriptor.Field(t => t.GetArtist(default))
				.Type<ArtistType>()
				.Argument("id", a => a.DefaultValue("a0000000-0000-0000-0000-000000000001"));

			descriptor.Field(t => t.GetAlbum(default))
				.Type<AlbumType>()
				.Argument("id", a => a.DefaultValue("b0000000-0000-0000-0000-000000000001"));

			descriptor.Field(t => t.GetSong(default))
				.Type<SongType>()
				.Argument("id", a => a.DefaultValue("c0000000-0000-0000-0000-000000000001"));
		}
	}
}
