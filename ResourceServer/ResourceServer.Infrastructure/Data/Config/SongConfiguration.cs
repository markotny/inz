using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceServer.Core.Entities;

namespace ResourceServer.Infrastructure.Data.Config
{
	public class SongConfiguration : IEntityTypeConfiguration<Song>
	{
		public void Configure(EntityTypeBuilder<Song> builder)
		{
			//builder.HasOne(t => t.Artist);

			//builder.Property(t => t.Title)
			//	.IsRequired();

			//builder.Property(t => t.Artist)
			//	.IsRequired();
		}
	}
}
