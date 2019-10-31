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
		}
	}
}
