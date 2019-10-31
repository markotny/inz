﻿using HotChocolate.Types;
using ResourceServer.Core.Entities;

namespace ResourceServer.Api.Types
{
	public class AlbumType : ObjectType<Album>
	{
		protected override void Configure(IObjectTypeDescriptor<Album> descriptor)
		{
		}
	}

	public class AlbumInputType : InputObjectType<Album>
	{
		protected override void Configure(IInputObjectTypeDescriptor<Album> descriptor)
		{
		}
	}
}
