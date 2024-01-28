using MagicVilla_MVC.Models.Dto;
using MagicVilla_MVC.Services.IServices;
using MagicVilla_Utils;

namespace MagicVilla_MVC.Services
{
    public class NumeroVillaService : BaseService, INumeroVillaService
    {
        public readonly IHttpClientFactory _httpClient;
        private string _villaUrl;

        public NumeroVillaService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:Api_url")!;
        }

        public Task<T> Actualizar<T>(NumeroVillaUpdateRequest dto)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.PUT;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/numerovilla/{dto.Id}";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Crear<T>(NumeroVillaCreateRequest dto)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.POST;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/numerovilla";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Obtener<T>(string id)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/numerovilla/{id}";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> ObtenerTodos<T>()
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/numerovilla";

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Remover<T>(int VillaNro)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.DELETE;
            ApiRequest.Url = $"{_villaUrl}/api/numerovilla/{VillaNro}";

            return SendAsync<T>(ApiRequest);
        }
    }
}
