namespace DesignDistrict.Frontend.API
{
    namespace WebApplication6.API
    {
        using System.Net.Http.Headers;
        using System.Net.Http;
        using global::WebApplication6.Model.Responses;
        using global::WebApplication6.Model;
        using global::WebApplication6.Model.Request;
        using ProductApi.Models.Requests;

        public class APIClient
        {
            private readonly HttpClient _api;
            public APIClient(IHttpContextAccessor accessor, IHttpClientFactory factory)
            {
                _api = factory.CreateClient("Api");

                var token = accessor.HttpContext.Session.GetString("Token");
                _api.DefaultRequestHeaders.Authorization =
                              new AuthenticationHeaderValue("Bearer", token);
            }

            public async Task<PageListResult<DesignDistrictResponse>> GetBanks()
            {
                var response = await _api
                    .GetFromJsonAsync<PageListResult<DesignDistrictResponse>>("api/DesignDistrict");
                return response;
            }
            public async Task<bool> Register(SignupRequest request)
            {
                var response = await _api.PostAsJsonAsync("/api/login/Registor", request);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            public async Task<string> Login(string username, string password)
            {
                var response = await _api.PostAsJsonAsync("/api/login",
                    new UserLoginRequest { Username = username, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadFromJsonAsync<UserLoginResponse>();

                    var token = tokenResponse.Token;
                    return token;
                }
                return "";
            }
        }
    }


}
