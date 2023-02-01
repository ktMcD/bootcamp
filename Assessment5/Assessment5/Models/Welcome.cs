using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Assessment5.Models
{
    public class Welcome
    {
        [Required]
        [MaxLength(50)]
        [DisplayName ("Login Name")]
        public string? Name { get; set; }

        public int? Length { get; set; }

        [Required]
            [DisplayName("Current Course")]
        public string? Password { get; set; }
    }
}
