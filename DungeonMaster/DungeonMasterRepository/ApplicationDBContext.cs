using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using DungeonMasterDTO;

namespace DungeonMasterRepository
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<DungeonCell> DungeonCells { get; set; }
        public DbSet<Npc> Npcs { get; set; }
        public DbSet<CharacterRace> CharacterRaces { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; } 
        public ApplicationDBContext() // required to have an empty constructor. Don't delete.
        {

        }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        private static IConfigurationRoot _configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("DungeonManager");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
                                                                                                                                                                                      
    }
}