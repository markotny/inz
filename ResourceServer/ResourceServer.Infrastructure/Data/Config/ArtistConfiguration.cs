using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceServer.Core.Entities;

namespace ResourceServer.Infrastructure.Data.Config
{
	public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
	{
		public void Configure(EntityTypeBuilder<Artist> builder)
		{
			//builder.HasMany(t => t.Albums);
			//builder.Property(t => t.Name)
			//	.IsRequired();
		}
	}
}
