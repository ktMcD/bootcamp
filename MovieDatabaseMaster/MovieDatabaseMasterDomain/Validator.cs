namespace MovieDatabaseMaster
{
    public static class Validator
    {
        public static string ValidatePatronResponse(string theMenuSelection)
        {
            string[] acceptableSelections = {"a", "b", "c", "q", "x"};
            for (int i = 0; i < acceptableSelections.Length; i++)
            {
                if (acceptableSelections[i] == theMenuSelection)
                {
                    return theMenuSelection;
                }
            }

            return "?";
        }
    }
}