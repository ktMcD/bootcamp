using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DungeonMasterDTO;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace DungeonMasterRepository
{
    public class DungeonNPCRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;
        public DungeonNPCRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DungeonManager"));
        }

        // ready for CRUD
    }
}
