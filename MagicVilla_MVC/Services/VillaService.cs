﻿using MagicVilla_MVC.Models.Dto;
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

        public Task<T> Actualizar<T>(VillaUpdateDto dto, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.PUT;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/v1/villa/{dto.Id}";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Crear<T>(VillaCreateDto dto, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.POST;
            ApiRequest.Datos = dto;
            ApiRequest.Url= $"{_villaUrl}/api/v1/villa";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Obtener<T>(string id, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/v1/villa/{id}";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> ObtenerTodos<T>(string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/v1/villa";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Remover<T>(string id, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.DELETE;
            ApiRequest.Url = $"{_villaUrl}/api/v1/villa/{id}";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }
    }
}
