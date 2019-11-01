using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class SongType : ObjectType<Song>
	{
		protected override void Configure(IObjectTypeDescriptor<Song> descriptor)
		{
		}
	}

	public class SongInputType : InputObjectType<Song>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Song> descriptor)
		{
			descriptor.Field(t => t.AlbumId)
				.Type<IdType>();

			descriptor.Field(t => t.ArtistId)
				.Type<NonNullType<IdType>>();
		}
	}
}
