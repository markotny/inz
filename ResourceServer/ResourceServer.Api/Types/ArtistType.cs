using HotChocolate.Types;
using HotChocolate.Types.Relay;
using ResourceServer.Api.Resolvers;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class ArtistType : ObjectType<Artist>
	{
		protected override void Configure(IObjectTypeDescriptor<Artist> descriptor)
		{
			descriptor.Field(t => t.Id)
				.Type<NonNullType<IdType>>();
		}
	}
}
