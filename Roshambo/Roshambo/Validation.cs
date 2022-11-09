using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo
{
    public class Validation
    {
        // validate for string values
        public bool ValidateHumanThrow(string textIn) // validate against the enum
        {
            List<string> roshamboThrows = new List<string>();
            roshamboThrows = Enum.GetNames(typeof(Roshambo)).ToList();
            return roshamboThrows.Contains(textIn);
        }

        public bool ValidateOpponent(string textIn)
        {
            if (textIn == "r" || textIn == "o")
            {
                return true;
            }
            return false;
        }
    }
}
