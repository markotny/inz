using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class ArtistType : ObjectType<Artist>
	{
		protected override void Configure(IObjectTypeDescriptor<Artist> descriptor)
		{
		}
	}
	public class ArtistInputType : InputObjectType<Artist>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Artist> descriptor)
		{
		}
	}
}
