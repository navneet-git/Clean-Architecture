using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class BaseRepository
    {
        public readonly string ConnectionString = string.Empty;
        private IConfiguration _configuration;
        public readonly SampleAppDBContext _dbContext;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(IConfiguration));
            ConnectionString = _configuration.GetConnectionString("SampleAppDb").ToString();
            _dbContext = new SampleAppDBContext(_configuration);
        }
    }
}
