using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoGame g = new VideoGame
            {
                title = "Zelda - Ocarina of time",
                cote = 10,
                editor = "Nintendo",
                typeGame = "a-rpg",
                nbrJoueurs = 1,
                plateForm = "N64"
            };

            
            Post(g);

            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i);
            }
            Console.Clear();

            foreach (VideoGame game in Get())
            {
                Console.WriteLine(game.title);
            }

            Console.ReadLine();
        }

        static List<VideoGame> Get()
        {
            //utilisation du http clien pour aller interroger l'api
            HttpClient _client = new HttpClient();
            //je passe l'uri de base qui sera composé de l'adresse du serveur local dans notre cas , du port et de /api/
            _client.BaseAddress = new Uri("http://localhost:64118/api/");
            //je lui dis d'interroger le controlleur concerné
            HttpResponseMessage message = _client.GetAsync("VideoGame").Result;
            //je récupère le status de la requete
            message.EnsureSuccessStatusCode();

            //Je stocke le résultat dans une variable de type string
            string Json = message.Content.ReadAsStringAsync().Result;

            //je convertir le json reçu en lis de jeux videos
            return JsonConvert.DeserializeObject<List<VideoGame>>(Json);
        }

        static async void Post(VideoGame game)
        {
            HttpClient _client = new HttpClient();
             _client.BaseAddress = new Uri("http://localhost:64118/api/");

            //je converti mon jeu au format json
            string json = JsonConvert.SerializeObject(game);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using(HttpResponseMessage response = await _client.PostAsync("VideoGame", content))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}
