using System.Net.Http.Json;

bool running = true;
bool hasShownMenu = false;
PlayerScore playerScore = new PlayerScore();
const string postKey = "1";
const string getKey = "2";

while (running)
{
    if (hasShownMenu)
    {
        Console.WriteLine("1. Continue\n2. Exit\n");
        string _input = Utility.GetInput();
        if (_input == "1")
        {

        }

        if (_input == "2")
        {
            running = false;
            return;
        }
    }
    PrintMenu();
    hasShownMenu = true;
    string input = Utility.GetInput();
    if (input == postKey)
    {
        HandlePost();
        continue;
    }

    if (input == getKey)
    {
        await NetworkManager.Instance.GetScore();
        continue;
    }

    if (input == "3")
    {
        running = false;
    }
}

static void PrintMenu()
{
    Console.WriteLine("=== ONLINE SCOREBOARD ===");
    Console.WriteLine("1. Submit Score\n2. View Scoreboard\n3. Exit\n\nChoose:");
}

void HandlePost(){
    Console.WriteLine("Please enter your name: ");
    string name = Utility.GetInput();
    if (!Utility.ValidateInput(name))
    {
        Console.WriteLine("Error, Invalid input!");
        return;
    }

    Console.WriteLine("Please enter your score: ");
    string? score = Utility.GetInput();
    if (!Utility.ValidateInput(score))
    {
        Console.WriteLine("Error, invalid input!");
        return;
    }

    playerScore.Name = name;
    playerScore.Score = Int32.Parse(score);

    NetworkManager.Instance.PostScore(playerScore);
}
