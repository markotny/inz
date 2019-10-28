using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class SongType : ObjectType<Song>
	{
		protected override void Configure(IObjectTypeDescriptor<Song> descriptor)
		{
			descriptor.Field(t => t.Title)
				.Type<NonNullType<StringType>>();

			descriptor.Field(t => t.Album)
				.Type<NonNullType<AlbumType>>();

			descriptor.Field(t => t.Artist)
				.Type<NonNullType<ArtistType>>();
		}
	}
	public class SongInputType : InputObjectType<Song>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Song> descriptor)
		{
			descriptor.Field(t => t.Id)
				.Type<UuidType>();

			descriptor.Field(t => t.Title)
				.Type<NonNullType<StringType>>();
		}
	}
}
