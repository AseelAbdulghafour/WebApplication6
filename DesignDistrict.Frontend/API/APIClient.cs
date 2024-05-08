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

                //var token = accessor?.HttpContext.Session.GetString("Token") ?? "";
                _api.DefaultRequestHeaders.Authorization =
                              new AuthenticationHeaderValue("Bearer", "");
            }

            public async Task<List<DesignDistrictResponse>> GetDesigns()
            {
                var response = await _api
                    .GetFromJsonAsync<List<DesignDistrictResponse>>("api/DesignDistrict");
                return response;
            }

            public async Task<List<DesignDistrictResponse>> MyPosts()
            {
                var response = await _api
                    .GetFromJsonAsync<List<DesignDistrictResponse>>("api/DesignDistrict/myposts");
                return response;
            }

            public async Task<List<DesignDistrictResponse>> DesignerList(int userId)
            {
                var response = await _api
                    .GetFromJsonAsync<List<DesignDistrictResponse>>($"api/DesignDistrict/{userId}");
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
                var response = await _api.PostAsJsonAsync("/api/login/login",
                    new UserLoginRequest { Username = username, Password = password });

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadFromJsonAsync<UserLoginResponse>();

                    var token = tokenResponse.Token;
                    return token;
                }
                return "";
            }

            public async Task<DesignDistrictResponse> PostDesign(PostRequest form)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "api/DesignDistrict/create");
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(form.PostImage.OpenReadStream()), form.PostImage.Name, form.PostImage.FileName);
                content.Add(new StringContent(form.PostDescription), "PostDescription");
                content.Add(new StringContent(form.CatagoryId.ToString()), "CatagoryId");
                content.Add(new StringContent(form.TotalPrice.ToString()), "TotalPrice");
                request.Content = content;
                var response = await _api.SendAsync(request);
                response.EnsureSuccessStatusCode();

                //var response = await _api.PostAsJsonAsync("api/DesignDistrict/create", request);

                if (response.IsSuccessStatusCode)
                {
                    var design = await response.Content.ReadFromJsonAsync<DesignDistrictResponse>();
                    return design;
                }

                return null;
            }
        }
    }


}
