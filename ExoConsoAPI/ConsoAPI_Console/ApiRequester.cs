using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoAPI_Console
{
	public class ApiRequester
	{
		#region Utilisation du 'HttpClient' pour interroger l'api
		// 
		HttpClient httpClient;

		#endregion

		#region Constructors
		
		public ApiRequester(string baseAdress)
		{
			httpClient = new HttpClient();

			// Je passe l'uri de base qui sera composé de l'adresse du serveur local dans notre cas, du port et de /api/...
			httpClient.BaseAddress = new Uri(baseAdress);

			// Nettoyage et set-up du HTTP Header
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
		}

		#endregion

		public TResult Get<TResult>(string uri)
		{
			// On interroge le controlleur concerné...
			using (HttpResponseMessage message = httpClient.GetAsync(uri).Result)
			{
				// Récupèration du statut de la requête...
				message.EnsureSuccessStatusCode();

				// On stocke le résultat dans une variable de type string...
				string json = message.Content.ReadAsStringAsync().Result;

				// On convertit le 'Json' reçu en liste du type souhaité.
				return JsonConvert.DeserializeObject<TResult>(json);
			}
		}

		public void Post<TBody>(TBody body, string uri)
		{
			// je converti mon jeu au format json
			string json = JsonConvert.SerializeObject(body);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage message = httpClient.PostAsync(uri, content).Result;

			if (!message.IsSuccessStatusCode)
				throw new HttpRequestException();
		}

		public void Update<TBody>(TBody body, string uri)
		{
			string json = JsonConvert.SerializeObject(body);
			HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpResponseMessage message = httpClient.PutAsync(uri, content).Result;

			if (!message.IsSuccessStatusCode)
				throw new HttpRequestException();
		}

		public void Delete(int id, string uri)
		{
			HttpResponseMessage message = httpClient.DeleteAsync(uri + id).Result;
			message.EnsureSuccessStatusCode();
		}
	}
}