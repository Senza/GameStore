using GameStoreFrontend.Models;

namespace GameStoreFrontend.Client;

public class GenreClient(HttpClient httpClient)
{

    public async Task<Genre[]> GetGenresAsync()
    {
        return await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
    }
}
