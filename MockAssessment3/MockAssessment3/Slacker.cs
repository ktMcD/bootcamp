﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockAssessment3
{
    public class Slacker : Villager
    {
        public Slacker()
        {
            Hunger = 3;
        }

        public override int Farm()
        {
            return 0;
        }
    }
}
