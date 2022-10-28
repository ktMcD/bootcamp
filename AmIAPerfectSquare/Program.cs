using System;

namespace AmIAPerfectSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool amIAPerfectSquare;
            var YesOrNo = new Program();
            amIAPerfectSquare = YesOrNo.DoTheWork();
            Console.WriteLine("Am I a perfect square? " + amIAPerfectSquare);
            Environment.Exit(0);
        }

        public bool DoTheWork()
        {
            string userInput = "";
            int theNumber = 0;
            int remainder = 0;
            double squared = 0;
            bool perfectSquare = false;
            Console.WriteLine("AmIAPerfectSquare?");
            Console.WriteLine("Please enter a number to evaluate");
            userInput = Console.ReadLine();
            theNumber = int.Parse(userInput);
            squared = Math.Sqrt(theNumber);
            perfectSquare = int.TryParse(squared.ToString(), out remainder);
            return perfectSquare;
        }
    }
}
