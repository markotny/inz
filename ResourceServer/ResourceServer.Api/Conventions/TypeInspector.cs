using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Namotion.Reflection;
using ResourceServer.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ResourceServer.Api.Conventions
{
	public class TypeInspector : DefaultTypeInspector
	{
		public override IEnumerable<MemberInfo> GetMembers(Type type)
		{
			return IgnoreForeignKeys(base.GetMembers(type));
		}

		public override ITypeReference GetReturnType(MemberInfo member, TypeContext context)
		{
			if (ExtendsBaseEntity(member.ReflectedType))
			{
				var contextualProperty = member.ReflectedType!.GetProperty(member.Name).ToContextualProperty();

				bool isNullable, isElementNullable;

				if (context == TypeContext.Input && ExtendsBaseEntity(contextualProperty.Type))
				{
					isNullable = true;
					isElementNullable = true;
				}
				else
				{
					isNullable = contextualProperty.Nullability == Nullability.Nullable;
					isElementNullable = contextualProperty.GenericArguments?.FirstOrDefault()?.Nullability == Nullability.Nullable;
				}

				return new ClrTypeReference(
					contextualProperty.Type,
					context,
					isNullable,
					isElementNullable)
					.Compile();
			}

			return base.GetReturnType(member, context);
		}

		private IEnumerable<MemberInfo> IgnoreForeignKeys(IEnumerable<MemberInfo> members)
		{
			return members.Where(member => member.Name.StartsWith("Id") || !member.Name.EndsWith("Id"));
		}

		private bool ExtendsBaseEntity(Type? type)
		{
			return type?.BaseType == typeof(BaseEntity<Guid>);
		}
	}
}