using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceServer.Api.Types
{
	public class QueryType : ObjectType<Query>
	{
		protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
		{
			descriptor.Field(t => t.GetToDoItem(default))
				.Type<ToDoItemType>()
				.Argument("id", a => a.DefaultValue(1));
		}
	}
}
