using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DungeonMasterDTO;
using Microsoft.Extensions.Options;

namespace DungeonMasterRepository
{
    public class DungeonCharacterRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;
        public DungeonCharacterRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DungeonManager"));
        }
    }
}
