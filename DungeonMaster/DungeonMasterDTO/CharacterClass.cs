using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterDTO
{
    public class CharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Character> Characters { get; set; } = new List<Character>();
    }
}
