using HotChocolate.Types;

namespace ResourceServer.Api.Types
{
	public class QueryType : ObjectType<Query>
	{
		protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
		{
			descriptor.Field(t => t.GetAlbums())
				.Type<NonNullType<ListType<NonNullType<AlbumType>>>>();

			descriptor.Field(t => t.SearchAlbums(default!, default!, default!))
				.Argument("mbid", a => a.Type<StringType>())
				.Argument("title", a => a.Type<NonNullType<StringType>>())
				.Argument("artist", a => a.Type<NonNullType<StringType>>())
				.Type<NonNullType<ListType<NonNullType<AlbumType>>>>();

			descriptor.Field(t => t.SearchArtists(default!, default!))
				.Argument("mbid", a => a.Type<StringType>())
				.Argument("name", a => a.Type<NonNullType<StringType>>())
				.Type<NonNullType<ListType<NonNullType<ArtistType>>>>();
		}
	}
}
