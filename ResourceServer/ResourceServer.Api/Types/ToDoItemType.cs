﻿using HotChocolate.Types;
using ResourceServer.Core.Entities;
using System;

namespace ResourceServer.Api.Types
{
	public class ToDoItemType : ObjectType<ToDoItem>
	{
		protected override void Configure(IObjectTypeDescriptor<ToDoItem> descriptor)
		{
			descriptor.Field(t => t.Description).Type<StringType>().Authorize();
		}
	}

	public class CreateToDoItemInput : InputObjectType<ToDoItem>
	{
		protected override void Configure(IInputObjectTypeDescriptor<ToDoItem> descriptor)
		{
			descriptor.Name("CreateToDoItemInput");
			descriptor.Field(t => t.Id).Ignore();
			descriptor.Field(t => t.IsDone).Ignore();
		}
	}

	public class UpdateToDoItemInput : InputObjectType<ToDoItem>
	{
		protected override void Configure(IInputObjectTypeDescriptor<ToDoItem> descriptor)
		{
			descriptor.Name("UpdateToDoItemInput");
		}
	}
}
