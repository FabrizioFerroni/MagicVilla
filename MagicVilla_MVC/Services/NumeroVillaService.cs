﻿using MagicVilla_MVC.Models.Dto;
using MagicVilla_MVC.Services.IServices;
using MagicVilla_Utils;
using NuGet.Common;

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

        public Task<T> Actualizar<T>(NumeroVillaUpdateRequest dto, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.PUT;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/v1/numerovilla/{dto.Id}";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Crear<T>(NumeroVillaCreateRequest dto, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.POST;
            ApiRequest.Datos = dto;
            ApiRequest.Url = $"{_villaUrl}/api/v1/numerovilla";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Obtener<T>(string id, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/v1/numerovilla/{id}";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> ObtenerTodos<T>(string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.GET;
            ApiRequest.Url = $"{_villaUrl}/api/v1/numerovilla";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }

        public Task<T> Remover<T>(int VillaNro, string token)
        {
            var ApiRequest = new ApiRequest();

            ApiRequest.ApiTipo = DS.ApiTipo.DELETE;
            ApiRequest.Url = $"{_villaUrl}/api/v1/numerovilla/{VillaNro}";
            ApiRequest.Token = token;

            return SendAsync<T>(ApiRequest);
        }
    }
}
