using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class AlbumType : ObjectType<Album>
	{
		protected override void Configure(IObjectTypeDescriptor<Album> descriptor)
		{
			descriptor.Field(t => t.MusicBrainzId)
				.Type<StringType>()
				.Name("mbid");
		}
	}

	public class AlbumInputType : InputObjectType<Album>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Album> descriptor)
		{
			descriptor.Field(t => t.MusicBrainzId)
				.Type<StringType>()
				.Name("mbid");

			descriptor.Field(t => t.AlbumArtistId)
				.Type<IdType>();
		}
	}
}
