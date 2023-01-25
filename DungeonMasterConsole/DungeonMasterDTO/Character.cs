using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DungeonMasterDTO
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CharacterName { get; set; }
        [Required]
        [DefaultValue(1)]
        public int CurrentLevel { get; set; }
        [Required]
        [DefaultValue(100)]
        public int HitPoints { get; set; }
        public string? BackStory { get; set; }
        public int? CharacterRaceId { get; set; }
        public virtual CharacterRace CharacterRace { get; set; }
        public int? CharacterClassId { get; set; }
        public virtual CharacterClass CharacterClass { get; set; }
        public virtual List<CharacterItemRelationship> Relationships { get; set; } = new List<CharacterItemRelationship>();

    }
}
