namespace MovieDatabaseMaster
{
    public static class Navigator
    {
        public static bool TryAgain(string theError)
        {
            string userResponse;
            switch (theError)
            {
                case "invalid entry":
                    Communicator.TalkToUser("Menu selections should only be entered as  alpha-numeric characters");
                    Communicator.TalkToUser("Valid selections are \"a\", \"b\", \"c\", \"q\", or \"x\"");
                    break;
                default:
                    break;
            }
            Communicator.TalkToUser("Would you like to select another menu item?");
            Communicator.TalkToUser("Enter \"y\" or \"yes\" to try again; anything else to quit");
            userResponse = Communicator.ListenToUser();
            if (userResponse.ToLower() != "y" && userResponse.ToLower() != "yes")
            {
                return false;
            }

            return true;
        }

        public static void ThankYouAndGoodbye()
        {
            Communicator.TalkToUser("Thank you for visiting today.");
            Communicator.TalkToUser("Please come back another time.");
            Console.WriteLine();
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}