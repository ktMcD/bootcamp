using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DungeonMasterDTO;
using DungeonMasterDomain;

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

        public static ItemViewModel ViewModelMapper(Item itemDTO)
        {
            return new ItemViewModel
            {
                Id = itemDTO.Id,
                Name = itemDTO.Name,
                Description = itemDTO.Description,
                AttackModifier = itemDTO.AttackModifier,
                DefenseModifier = itemDTO.DefenseModifier,
                Lore = itemDTO.Lore,
                IsEnchanted = itemDTO.IsEnchanted == null ? false : (bool)itemDTO.IsEnchanted,
                IsBreakable = itemDTO.IsBreakable == null ? false : (bool)itemDTO.IsBreakable
            };
        }


    }
}
