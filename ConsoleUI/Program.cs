using FluentEmail.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            RestSharp.RestClient restClient = new RestSharp.RestClient("https://api.spotify.com/v1/artists/1x0UGhijHGBX0bhm9ulj0Y");

			restClient.Authenticator = new RestSharp.Authenticators.OAuth2AuthorizationRequestHeaderAuthenticator($"BQDIeG9W9duFov8A5jDZutwgah8ul2xuiEi00iwcUz1cQ6eEuMUTCY2ycXspZmph0M5leRLJAxz7FLuOEI0", "Bearer");

			var resultRest = restClient.Execute(new RestSharp.RestRequest(), RestSharp.Method.GET);
		}

		public static string GetAuthorizationToken()
		{
			string url = "https://accounts.spotify.com/api/token";
			string HtmlResult;
			//Basic <base64 encoded client_id:client_secret>
			//Basic ODliNTMwZTAzNmZlNGY1YjkzN2YzYTI5NDJmM2VjZjE6OTFlM2U3YTFhMmU2NGUxNzliMDEwMzEwMjk1ZGU4Yjg=
			using (WebClient wc = new WebClient())
			{
				wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
				//wc.Headers["grant_type"] = "client_credentials";      BODY
				wc.Headers["Authorization"] = "Basic ODliNTMwZTAzNmZlNGY1YjkzN2YzYTI5NDJmM2VjZjE6OTFlM2U3YTFhMmU2NGUxNzliMDEwMzEwMjk1ZGU4Yjg=";
				HtmlResult = wc.UploadString(url, "POST", "grant_type=client_credentials");
			}
			var result = System.Text.Json.JsonSerializer.Deserialize<Token>(HtmlResult);
			//check result
			return result.AccessToken;
		}
	}

    public class Token
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }
    }

	//public class RestClient
	//{
	//	/*private readonly IHttpContextAccessor _httpContextAccessor;
	//	public RestClient(IHttpContextAccessor httpContextAccessor) =>
	//		_httpContextAccessor = httpContextAccessor;*/

	//	private static readonly HttpClient _client = new HttpClient();
	//	private string _apiLink { get; set; }
	//	public RestClient(string apiLink) => _apiLink = apiLink;

	//	public string ResponseMessage { get; set; }
	//	public bool IsSuccessful { get; set; }
	//	public HttpResponseMessage Response { get; set; }


	//	/// <summary>
	//	/// Asynchroniczne wysłanie requestu do ApiLink(appsettings.json)/endpoint 
	//	/// </summary>
	//	/// <param name="endpoint"></param>
	//	/// <param name="method"></param>
	//	/// <param name="data">String do wysłania</param>
	//	/// <returns>Status</returns>
	//	public async Task<bool> RequestAsync(string endpoint, HttpMethod method, string data, string senderId)
	//		=> await makeRequest(endpoint, method, data, senderId);

	//	/// <summary>
	//	/// Asynchroniczne wysłanie requestu do ApiLink(appsettings.json)/endpoint 
	//	/// </summary>
	//	/// <param name="endpoint"></param>
	//	/// <param name="method"></param>
	//	/// <param name="data">Obiekt do wysłania</param>
	//	/// <returns>Status</returns>
	//	public async Task<bool> RequestAsync(string endpoint, HttpMethod method, object data, string senderId)
	//		=> await makeRequest(endpoint, method, data, senderId);

	//	/// <summary>
	//	/// Asynchroniczne wysłanie requestu do ApiLink(appsettings.json)/endpoint 
	//	/// </summary>
	//	/// <param name="endpoint"></param>
	//	/// <param name="method"></param>
	//	/// <param name="data">Obiekt do wysłania (zostanie zserializowany)</param>
	//	/// <returns>Status</returns>
	//	public async Task<bool> RequestAsync(string endpoint, HttpMethod method, MultipartFormDataContent data, string senderId)
	//		=> await makeRequest(endpoint, method, data, senderId);


	//	private async Task<bool> makeRequest(string endpoint, HttpMethod method, object data, string senderId)
	//	{
	//		if (data is string && data as string == "")
	//			data = null;
	//		ResponseMessage = null;
	//		Response = null;
	//		IsSuccessful = false;


	//		try
	//		{
	//			var uri = new Uri(_apiLink + endpoint);
	//			Console.WriteLine(uri.ToString());
	//			var request = new HttpRequestMessage(method, uri);

	//			//var senderId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
	//			request.Headers.Add("SenderId", senderId);
	//			if (data != null)
	//				if (data is string)
	//					request.Content = new StringContent(data as string, Encoding.UTF8, "application/json");
	//				else if (data is MultipartFormDataContent)
	//					request.Content = data as MultipartFormDataContent;
	//				else
	//					request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");


	//			Response = await _client.SendAsync(request);
	//			ResponseMessage = await Response.Content.ReadAsStringAsync();

	//			IsSuccessful = Response.IsSuccessStatusCode;

	//			return true;
	//		}
	//		catch (HttpRequestException ex)
	//		{
	//			Console.WriteLine(ex.InnerException.Message);
	//			Response = new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable);
	//			ResponseMessage = ex.Message;
	//			return false;
	//		}
	//	}
	//}
}