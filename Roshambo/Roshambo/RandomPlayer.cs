using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo
{
    public class RandomPlayer :Player
    {
        public override string Name { get; set; }
        public override string RoshamboValue { get; set; }

        public RandomPlayer()
        {
            Name = "Randy";
            RoshamboValue = GenerateRoshambo();
        }

        public override string GenerateRoshambo()
        {
            string roThrow = "";
            int randomThrow = GetRandomNumber();
            switch (randomThrow)
            {
                case 1:
                {
                    roThrow = "rock";
                    break;
                }
                case 2:
                {
                    roThrow = "paper";
                    break;
                }

                default:
                {
                    roThrow = "scissors";
                    break;
                }
            }
            return roThrow;

        }

        private int GetRandomNumber()
        {
            Random randomNumber = new Random();
            int randomThrow = randomNumber.Next(1, 3);
            return randomThrow;

        }
    }
}
