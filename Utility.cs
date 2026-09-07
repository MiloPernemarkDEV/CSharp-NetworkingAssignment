public static class Utility {
    public static string GetInput()
    {
        string? result = Console.ReadLine();
        if (result != null)
        {
            return result;
        }
        Console.WriteLine("Failed to read user input!");
        return "";
    }

    public static bool ValidateInput(string input){
        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int score)){
            return false;
        }

        if (score < 0)
            return false;

        return true;
    }

}
