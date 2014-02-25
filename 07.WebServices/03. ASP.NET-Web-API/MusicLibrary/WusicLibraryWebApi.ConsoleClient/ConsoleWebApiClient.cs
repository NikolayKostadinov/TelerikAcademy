namespace WusicLibraryWebApi.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using MusicLibrary.Models;

    class ConsoleWebApiClient
    {
        internal static void Main()
        {
            ReadSongsAsync().Wait();
        }

        private static async Task ReadSongsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:18316/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                await GetSongsAsync(client);
            }
        }

        private static async Task GetSongsAsync(HttpClient client)
        {

            // New code:
            HttpResponseMessage response = await client.GetAsync("api/Songs");
            if (response.IsSuccessStatusCode)
            {
                var songs = await response.Content.ReadAsAsync<IEnumerable<Song>>();
                foreach (var song in songs)
                {
                    Console.WriteLine("{0}  {1}\t{2}\t{3:MM/dd/yyyy}  {4}", 
                        song.SongId, song.Title, song.Album.Title, 
                        song.Album.ReleaseDate, song.Artist.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
