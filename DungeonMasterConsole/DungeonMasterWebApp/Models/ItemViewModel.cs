using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DungeonMasterWebApp
{
    public class ItemViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public int? AttackModifier { get; set; }
        public int? DefenseModifier { get; set; }
        public string? Lore { get; set; }

        [DisplayName("Is Item Enchanted")]
        public bool IsEnchanted { get; set; } = false;

        [DisplayName("Is Item Breakable")]
        public bool IsBreakable { get; set; } = true;
    }
}
