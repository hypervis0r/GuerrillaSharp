using GuerrillaSharp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

namespace GuerrillaSharp
{
	public class GuerrillaMail
	{
		private readonly HttpClientHandler httpClientHandler;
		private readonly HttpClient httpClient;

		private readonly CookieContainer Cookies;

		[JsonProperty("sid_token")]
		private string SidToken { get; set; }

		[JsonProperty("email_addr")]
		public string EmailAddress { get; set; }

		[JsonProperty("email_timestamp")]
		public string EmailTimestamp { get; set; }

		[JsonProperty("alias")]
		public string EmailAlias { get; set; }

		[JsonProperty("list")]
		public List<Email> Emails { get; set; }

		[JsonProperty("count")]
		public int EmailCount { get { return Emails.Count; } }

		[JsonProperty("stats")]
		public Stats Stats { get; set; }

		public GuerrillaMail()
        {
			Cookies = new CookieContainer();

			httpClientHandler = new HttpClientHandler();

			httpClientHandler.CookieContainer = Cookies;

			httpClient = new HttpClient(httpClientHandler);
		}

		private async Task<Response> MakeGetRequest(string url, CookieContainer cookies)
		{
			//httpClientHandler.CookieContainer = cookies;
			var res = await httpClient.GetAsync(url);

			var jsonContent = await res.Content.ReadAsStringAsync();

			Response response = new Response()
			{
				Json = jsonContent,
				Cookies = httpClientHandler.CookieContainer
			};

			return response;
		}

		public async Task GetEmailAddress()
		{
			CookieContainer cookies = new CookieContainer();
			string url = "https://api.guerrillamail.com/ajax.php?f=get_email_address";
			Response response = await MakeGetRequest(url, cookies);

			GuerrillaMail tempmail = JsonConvert.DeserializeObject<GuerrillaMail>(response.Json);
			this.EmailAddress = tempmail.EmailAddress;
			this.EmailAlias = tempmail.EmailAlias;
			this.EmailTimestamp = tempmail.EmailTimestamp;

			this.SidToken = tempmail.SidToken;
		}

		public async Task<List<Email>> CheckEmail()
		{
			string url = "https://api.guerrillamail.com/ajax.php?f=check_email&seq=0&sid_token=" + this.SidToken;
			Response response = await MakeGetRequest(url, Cookies);

			CheckEmailResponse tempmail = JsonConvert.DeserializeObject<CheckEmailResponse>(response.Json);
			//this.Emails = tempmail.Emails;
			this.SidToken = tempmail.SidToken;

			return tempmail.Emails;
		}
		public async Task<Email> FetchEmail(string id)
		{
			string url = "https://api.guerrillamail.com/ajax.php?f=fetch_email&email_id=" + id;
			Response response = await MakeGetRequest(url, Cookies);

			Email email = JsonConvert.DeserializeObject<Email>(response.Json);
			return email;
		}
	}
}
