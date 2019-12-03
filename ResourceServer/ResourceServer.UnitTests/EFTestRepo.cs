using Microsoft.EntityFrameworkCore;
using ResourceServer.Infrastructure.Data;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using ResourceServer.Core.Interfaces;

namespace ResourceServer.Tests
{
	public abstract class EFTestRepo
	{
		protected AppDbContext _dbContext;

		protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
		{
			// Create a fresh service provider, and therefore a fresh
			// InMemory database instance.
			var serviceProvider = new ServiceCollection()
				.AddEntityFrameworkInMemoryDatabase()
				.BuildServiceProvider();

			// Create a new options instance telling the context to use an
			// InMemory database and the new service provider.
			var builder = new DbContextOptionsBuilder<AppDbContext>();
			builder.UseInMemoryDatabase("reServerDBtest")
				   .UseInternalServiceProvider(serviceProvider);

			return builder.Options;
		}

		protected EfRepository GetRepository()
		{
			var options = CreateNewContextOptions();
			var mockDispatcher = new Mock<IDomainEventDispatcher>();

			_dbContext = new AppDbContext(options, mockDispatcher.Object);
			return new EfRepository(_dbContext);
		}

	}
}
