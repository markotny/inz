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
				var contextualProperty = (member as PropertyInfo).ToContextualProperty();

				var isCollectionType = contextualProperty.GenericArguments?.Any() ?? false;

				bool isNullable, isElementNullable;

				if (context == TypeContext.Input &&
					(IsPrimaryKey(member) || ExtendsBaseEntity(contextualProperty.Type) || isCollectionType))
				{
					isNullable = true;
					isElementNullable = true;
				}
				else
				{
					isNullable = contextualProperty.Nullability == Nullability.Nullable;
					isElementNullable = isCollectionType
						? contextualProperty.GenericArguments![0].Nullability == Nullability.Nullable
						: true;
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
			return members.Where(member => IsPrimaryKey(member) || !member.Name.EndsWith("Id"));
		}

		private bool ExtendsBaseEntity(Type? type)
		{
			return type?.BaseType == typeof(BaseEntity);
		}

		private bool IsPrimaryKey(MemberInfo member)
		{
			return member.Name.Equals("Id");
		}
	}
}