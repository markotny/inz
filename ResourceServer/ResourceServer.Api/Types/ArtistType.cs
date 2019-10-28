using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class ArtistType : ObjectType<Artist>
	{
		protected override void Configure(IObjectTypeDescriptor<Artist> descriptor)
		{
			descriptor.Field(t => t.Name)
				.Type<NonNullType<StringType>>();

			descriptor.Field(t => t.Albums)
				.Type<NonNullType<ListType<NonNullType<AlbumType>>>>();

			descriptor.Field(t => t.Songs)
				.Type<NonNullType<ListType<NonNullType<SongType>>>>();
		}
	}
	public class ArtistInputType : InputObjectType<Artist>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Artist> descriptor)
		{
			descriptor.Field(t => t.Id)
				.Type<UuidType>();

			descriptor.Field(t => t.Name)
				.Type<NonNullType<StringType>>();
		}
	}
}
