using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class AlbumType : ObjectType<Album>
	{
		protected override void Configure(IObjectTypeDescriptor<Album> descriptor)
		{
			descriptor.Field(t => t.AlbumArtist)
				.Type<NonNullType<ArtistType>>();

			descriptor.Field(t => t.Songs)
				.Type<NonNullType<ListType<NonNullType<SongType>>>>();

			descriptor.Field(t => t.Title)
				.Type<NonNullType<StringType>>();
		}
	}

	public class AlbumInputType : InputObjectType<Album>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Album> descriptor)
		{
			descriptor.Field(t => t.Id)
				.Type<UuidType>();

			descriptor.Field(t => t.Title)
				.Type<NonNullType<StringType>>();
		}
	}
}
