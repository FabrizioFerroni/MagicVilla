using MagicVilla_MVC.Models.Dto;
using MagicVilla_MVC.Services.IServices;
using MagicVilla_Utils;

namespace MagicVilla_MVC.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {

        public readonly IHttpClientFactory _httpClient;
        private string _villaUrl;

        public UsuarioService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:Api_url")!;
        }

        public Task<T> Login<T>(LoginRequestDto dto)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.POST;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/v1/usuario/login";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Register<T>(RegistroRequestDto dto)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.POST;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/v1/usuario/register";

            return SendAsync<T>(ApiRequest);
        }
    }
}
