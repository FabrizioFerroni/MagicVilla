using MagicVilla_MVC.Models.Dto;
using MagicVilla_MVC.Services.IServices;
using MagicVilla_Utils;

namespace MagicVilla_MVC.Services
{
    public class VillaService : BaseService, IVillaService
    {
        public readonly IHttpClientFactory _httpClient;
        private string _villaUrl;

        public VillaService(IHttpClientFactory httpClient, IConfiguration configuration): base(httpClient)
        {
            _httpClient = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:Api_url")!;
        }

        public Task<T> Actualizar<T>(VillaUpdateDto dto)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.PUT;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/villa/{dto.Id}";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Crear<T>(VillaCreateDto dto)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.POST;
            ApiRequest.Datos = dto;
            ApiRequest.Url= $"{_villaUrl}/api/villa";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Obtener<T>(string id)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/villa/{id}";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> ObtenerTodos<T>()
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/villa";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Remover<T>(string id)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.DELETE;
            ApiRequest.Url = $"{_villaUrl}/api/villa/{id}";

            return SendAsync<T>(ApiRequest);
        }
    }
}
