using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class RatingType : ObjectType<Rating>
	{
		protected override void Configure(IObjectTypeDescriptor<Rating> descriptor)
		{
		}
	}
	public class RatingInputType : InputObjectType<Rating>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Rating> descriptor)
		{
			descriptor.Field(t => t.UserId)
				.Type<IdType>();
		}
	}
}
