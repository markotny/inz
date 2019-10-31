using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class ReviewType : ObjectType<Review>
	{
		protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
		{
		}
	}

	public class ReviewInputType : InputObjectType<Review>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Review> descriptor)
		{
		}
	}
}