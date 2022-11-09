using Roshambo;

namespace Roshambo
{
    public class Program
    {
        Communication speakWithUser = new Communication();
        Validation checkDataEntry = new Validation();
        string humanPlayerName = "friend";
        int randyScore = 0;
        int rockyScore = 0;
        int humanScore = 0;
        int totalGames = 0;

        private static void Main(string[] args)
        {
            Program HumanPlayer = new Program();
            HumanPlayer.PlayRoshambo();
        }

        private void PlayRoshambo()
        {
            bool playAgain = true;
            string opponent;
            string humanPlayerResponse;
            string opponentMove;
            string humanThrow;
            string winner;
            while (playAgain)
            {
                // ask the human player for their name
                speakWithUser.TalkToUser("Greetings! What's your name?");
                humanPlayerResponse = speakWithUser.ListenToUser();
                speakWithUser.TalkToUser(humanPlayerResponse);
                AssignHumanPlayerName(humanPlayerResponse);
                // give the human player a choice of opponents
                opponent = SelectOpponent();
                // call method to activate selected opponent
                opponentMove = MoveOpponent(opponent);
                // ask human player for their throw
                humanThrow = GetHumanPlayerThrow();
                // figure out and announce winner
                winner = FindTheWinner(humanThrow, opponent, opponentMove);
                speakWithUser.TalkToUser("The winner for this round is: ", winner);
                // increment total games and add one to the winner's score variable
                UpdateStats(winner);
                // ask Human Player if they'd like to play again
                playAgain = WannaPlayAgain();
                if (!playAgain)
                {
                    // display the overall results of the sesh, total games played and who won what
                    // end the process
                    ReportStats();
                    ThankYouForPlaying();
                }
            }
        }

        private void AssignHumanPlayerName(string humanName)
        {
            // humanPlayerName defaults to "friend" if null or ""
            // so we'll only update if we have a non-blank/null value 
            if (humanName != "" && humanName != null)
            {
                humanPlayerName = humanName;
            }
        }

        private string SelectOpponent()
        {
            string selectedOpponent = "";
            bool validOpponent = false;
            bool tryAgain = false;
            do
            {
                speakWithUser.TalkToUser("With whom would you like to play?");
                speakWithUser.TalkToUser("Type \"r\" for Randy Random or \"o\" for Rocky Rock");
                selectedOpponent = speakWithUser.ListenToUser().Trim().ToLower();
                validOpponent = checkDataEntry.ValidateOpponent(selectedOpponent);
                if (!validOpponent)
                {
                    tryAgain = TryAgain("invalid opponent");
                    if (!tryAgain)
                    {
                        ThankYouForPlaying();
                    }
                }
            } while (tryAgain);
            return selectedOpponent;
        }

        private string MoveOpponent(string opponent)
        {
            string opponentMove = "";
            switch (opponent)
            {
                case "rocky":
                    RockPlayer rocky = new RockPlayer();
                    opponentMove = rocky.GenerateRoshambo(); // always gonna be rock
                    break;
                case "randy":
                    RandomPlayer randy = new RandomPlayer();
                    opponentMove = randy.GenerateRoshambo();
                    break;
                default: // this should never happen since we validate before getting here; but just in case...
                    opponentMove = "woopsy! something bad happened";
                    break;
            }
            return opponentMove;
        }

        private string GetHumanPlayerThrow()
        {
            string playerThrow = "";
            bool validThrow = false;
            bool keepTrying = true;
            while (keepTrying)
            {
                speakWithUser.TalkToUser("What is your Roshambo throw?");
                speakWithUser.TalkToUser("Please select \"r\" for Rock, \"p\" for Paper or \"s\" for Scissors");
                playerThrow = speakWithUser.ListenToUser().ToLower();
                validThrow = checkDataEntry.ValidateHumanThrow(playerThrow);
                if (!validThrow)
                {
                    keepTrying = TryAgain("invalid throw");
                    if (!keepTrying)
                    {
                        ThankYouForPlaying();
                    }
                }
            }
            switch (playerThrow)
            {
                case "r":
                    playerThrow = "rock";
                    break;
                case "p":
                    playerThrow = "paper";
                    break;
                default:
                    playerThrow = "scissors";
                    break;
            }
            return playerThrow;
        }

        private string FindTheWinner(string human, string opponent, string opponentThrow)
        {
            string theWinner = "";
            speakWithUser.TalkToUser($"Great! You chose {human}.");
            speakWithUser.TalkToUser($"{opponent} chose {opponentThrow}.");
            switch (human)
            {
                case "rock":
                    switch (opponentThrow)
                    {
                        case "rock":
                            theWinner = "draw";
                            break;
                        case "paper":
                            theWinner = humanPlayerName;
                            break;
                        case "scissors":
                            theWinner = opponent;
                            break;
                    }
                    break;
                case "paper":
                    switch (opponentThrow)
                    {
                        case "rock":
                            theWinner = humanPlayerName;
                            break;
                        case "paper":
                            theWinner = "draw";
                            break;
                        case "scissors":
                            theWinner = opponent;
                            break;
                    }
                    break;
                case "scissors":
                    switch (opponentThrow)
                    {
                        case "rock":
                            theWinner = opponent;
                            break;
                        case "paper":
                            theWinner = humanPlayerName;
                            break;
                        case "scissors":
                            theWinner = "draw";
                            break;
                    }
                    break;
                default:
                    theWinner = "";
                    break;

            }
            return theWinner;
        }

        private void UpdateStats(string winner)
        {
            totalGames += 1;
            switch (winner)
            {
                case "rocky":
                    rockyScore += 1;
                    break;
                case "randy":
                    randyScore += 1;
                    break;
                default:
                    humanScore += 1;
                    break;
            }

        }

        private void ReportStats()
        {
            speakWithUser.TalkToUser("Here are your stats for this session:");
            speakWithUser.TalkToUser("Games you won: ", humanScore.ToString());
            speakWithUser.TalkToUser("Games Rocky won: ", rockyScore.ToString());
            speakWithUser.TalkToUser("Games Randy won: ", randyScore.ToString());
            speakWithUser.TalkToUser("Total games played: ", totalGames.ToString());
        }

        private bool TryAgain(string errorMessage)
        {
            string messageToUser = "";
            switch (errorMessage)
            {
                case "invalid opponent":
                    messageToUser = "You have entered an invalid opponent";
                    break;
                case "invalid throw":
                    messageToUser = "Your throw selection is invalid.\n" +
                                    "Please only select Rock (\"r\"), Paper (\"p\") or Scissors (\"s\")";
                    break;
            }
            speakWithUser.TalkToUser(messageToUser);
            speakWithUser.TalkToUser("If you quit now, your stats might now be accurate");
            return WannaPlayAgain();
        }

        private bool WannaPlayAgain()
        {
            string humanPlayerResponse;
            speakWithUser.TalkToUser("Would you like to give it another whirl? \"y\" or \"yes\" to continue");
            speakWithUser.TalkToUser("Anything else to quit");
            humanPlayerResponse= speakWithUser.ListenToUser().Trim().ToLower();
            if (humanPlayerResponse != "y" && humanPlayerResponse != "yes")
            {
                return true;
            }
            return false;
        }

        private void ThankYouForPlaying()
        {
            ReportStats();
            speakWithUser.TalkToUser("Great to play with you. Come back soon.");
            speakWithUser.TalkToUser("So long!");
            Console.ReadKey();
            Environment.Exit(0);

        }
    }
}