using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceServer.Api.Types
{
	public class MutationType : ObjectType<Mutation>
	{
		protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
		{
			descriptor.Field(t => t.AddToDoItem(default))
				.Argument("input", a => a.Type<CreateToDoItemInput>())
				.Type<NonNullType<ToDoItemType>>();

			descriptor.Field(t => t.UpdateToDoItem(default))
				.Argument("input", a => a.Type<UpdateToDoItemInput>())
				.Type<NonNullType<ToDoItemType>>();

		}
	}
}
