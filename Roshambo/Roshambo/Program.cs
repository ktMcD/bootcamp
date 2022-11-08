using Roshambo;

namespace Roshambo
{
    public class Program
    {
        RandomPlayer randy = new RandomPlayer();
        RockPlayer rocky = new RockPlayer();
        string humanPlayerName = "friend";
        int randyScore = 0;
        int rockScore = 0;
        int humanScore = 0;
        int totalGames = 0;

        private static void Main(string[] args)
        {
            Program HumanPlayer = new Program();
            HumanPlayer.PlayRoshambo();
        }

        private void PlayRoshambo()
        {
            Communication speakWithUser = new Communication();
            bool playAgain = true;
            string humanPlayerResponse;
            while (playAgain)
            {
                // ask the human player for their name
                speakWithUser.TalkToUser("Greetings! What's your name?");
                humanPlayerResponse = speakWithUser.ListenToUser();
                AssignHumanPlayerName(humanPlayerResponse);
                // give the human player a choice of opponents
                // call method to activate selected opponent
                // ask user for their move
                // announce winner
                // increment total games and add one to the winner's score variable
                // ask Human Player if they'd like to play again
            }
        }

        private void AssignHumanPlayerName(string humanName)
        {
            if (humanName != "" && humanName != null)
            {
                humanPlayerName = humanName;
            }  
        }
    }
}