using System;
using ResourceServer.Core.SharedKernel;
using System.Collections.Generic;
using System.Text;

namespace ResourceServer.Core.Entities
{
	public class Rating : BaseEntity
	{
		private User? _user;
		private Album? _album;

		public short Stars { get; set; }
		public Guid UserId { get; set; }

		public virtual User User
		{
			get => NavigationPropertyAccessor(_user);
			set => _user = value;
		}

		public Guid AlbumId { get; set; }

		public virtual Album Album
		{
			get => NavigationPropertyAccessor(_album);
			set => _album = value;
		}

		public virtual Review? Review { get; set; }
	}
}
