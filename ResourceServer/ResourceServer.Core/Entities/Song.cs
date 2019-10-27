using ResourceServer.Core.SharedKernel;

namespace ResourceServer.Core.Entities
{
	public class Song : BaseEntity<string>
	{
		public string Title { get; set; }
		public virtual Album Album { get; set; }
		public virtual Artist Artist { get; set; }
		public int Length { get; set; }
		public int TrackNumber { get; set; }
	}
}
