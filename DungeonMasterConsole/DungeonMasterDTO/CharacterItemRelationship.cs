using System.ComponentModel.DataAnnotations;

namespace DungeonMasterDTO
{
    public class CharacterItemRelationship
    {
        [Key]
        public int RelationshipId { get; set; }
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

    }
}
