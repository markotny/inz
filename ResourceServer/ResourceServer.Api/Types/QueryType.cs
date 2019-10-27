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
			descriptor.Field(t => t.GetToDoItem(default))
				.Type<ToDoItemType>()
				.Argument("id", a => a.DefaultValue(1));

			descriptor.Field(t => t.GetArtist(default))
				.Type<ArtistType>()
				.Argument("id", a => a.DefaultValue("artist1"));

			descriptor.Field(t => t.GetAlbum(default))
				.Type<AlbumType>()
				.Argument("id", a => a.DefaultValue("album1"));

			descriptor.Field(t => t.GetSong(default))
				.Type<SongType>()
				.Argument("id", a => a.DefaultValue("song1"));
		}
	}
}
