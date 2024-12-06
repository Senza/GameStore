using GameStoreFrontend.Models;

namespace GameStoreFrontend.Client;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAysnc()
    {
        return await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
    }
    public async Task AddGameAsync(GameDetails gameDetails)
    {
        await httpClient.PostAsJsonAsync("games", gameDetails);
    }

    public async Task<GameDetails> GetGameAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
            ?? throw new Exception("could not find games");
    }

    public async Task DeleteGameAsync(int id)
    {
        await httpClient.DeleteAsync($"games/{id}");
    }
    public async Task UpdateGameAsync(GameDetails gameDetails)
    {
        await httpClient.PutAsJsonAsync($"games/{gameDetails.Id}", gameDetails);
    }


}
