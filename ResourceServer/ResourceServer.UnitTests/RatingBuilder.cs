using ResourceServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceServer.Tests
{
	public class RatingBuilder
	{
		private Rating _rating = new Rating();

		public RatingBuilder Id(Guid id)
		{
			_rating.Id = id;
			return this;
		}
		public RatingBuilder Stars(short stars)
		{
			_rating.Stars = stars;
			return this;
		}
		public RatingBuilder Review(string review)
		{
			_rating.Review = review;
			return this;
		}
		public RatingBuilder User(User user)
		{
			_rating.User = user;
			return this;
		}
		public RatingBuilder WithDefaultValues()
		{
			_rating = new Rating
			{
				Id = new Guid(),
				Stars = 5,
				Review = "Test Review",
				UserId = new Guid("e0000000000000000000000000000001")
			};
			return this;
		}
		public Rating Build() => _rating;
	}
}
