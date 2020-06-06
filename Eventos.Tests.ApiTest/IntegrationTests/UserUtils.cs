using Eventos.Services.Api.ViewModels;
using Eventos.Tests.ApiTest.IntegrationTests.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Tests.ApiTest.IntegrationTests
{
    public class UserUtils
    {
		public static async Task<string> RealizarLogin(HttpClient client)
		{
			var user = new UserLoginViewModel
			{
				UserName = "marcos",
				Password = "123456"
			};

			var postContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("api/user/login", postContent);

			var postResult = await response.Content.ReadAsStringAsync();
			var userResult = JsonConvert.DeserializeObject<UsuarioJsonDTO>(postResult);

			return userResult.token;
		}

	}
}
