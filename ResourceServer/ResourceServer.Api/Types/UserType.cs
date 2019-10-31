using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class UserType : ObjectType<User>
	{
		protected override void Configure(IObjectTypeDescriptor<User> descriptor)
		{
		}
	}
	public class UserInputType : InputObjectType<User>
	{
		protected override void Configure(IInputObjectTypeDescriptor<User> descriptor)
		{
		}
	}
}
