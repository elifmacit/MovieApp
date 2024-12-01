using MovieApp.Data.External.Movies;
using System.Text.Json;

namespace MovieApp.ExternalServices.OMDB
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        public MovieService(IHttpClientFactory httpClientFactory) 
        {
            _httpClient = httpClientFactory.CreateClient("OMDBClient");
        }

        public async Task<Movie?> GetMovieByIdAsync(string movieId)
        {
            var response = await _httpClient.GetStringAsync($"?i={movieId}&apikey=71dd150");
            return JsonSerializer.Deserialize<Movie>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }


    }
}
