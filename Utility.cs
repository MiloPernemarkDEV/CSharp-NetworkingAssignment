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

}
