using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class ArtistType : ObjectType<Artist>
	{
		protected override void Configure(IObjectTypeDescriptor<Artist> descriptor)
		{
			descriptor.Field(t => t.MusicBrainzId)
				.Type<StringType>()
				.Name("mbid");
		}
	}
	public class ArtistInputType : InputObjectType<Artist>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Artist> descriptor)
		{
			descriptor.Field(t => t.MusicBrainzId)
				.Type<StringType>()
				.Name("mbid");
		}
	}
}
