using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceServer.Core.Entities;

namespace ResourceServer.Infrastructure.Data.Config
{
	public class AlbumConfiguration : IEntityTypeConfiguration<Album>
	{
		public void Configure(EntityTypeBuilder<Album> builder)
		{
			builder.Property(t => t.Title)
				.IsRequired();
		}
	}
}
