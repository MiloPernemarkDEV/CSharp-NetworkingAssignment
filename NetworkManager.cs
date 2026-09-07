using System.Net.Http.Json;


class NetworkManager
{
    public static NetworkManager Instance { get; } = new NetworkManager();

    static string scoreboardUrl = "https://scoreboard-f26-default-rtdb.europe-west1.firebasedatabase.app/scores.json";

    public async Task PostScore(PlayerScore playerScore)
    {
        try
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage postResponse = await client.PostAsJsonAsync(scoreboardUrl, playerScore);

            postResponse.EnsureSuccessStatusCode();
            string result = await postResponse.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public async Task GetScore()
    {
        try
        {
            HttpClient client = new HttpClient();
            Dictionary<string, ScoreEntry>? scores = await client.GetFromJsonAsync<Dictionary<string, ScoreEntry>>(scoreboardUrl);
            foreach (ScoreEntry score in scores.Values)
            {
                Console.WriteLine($"{score.Name}: {score.Score}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }
    }

}
