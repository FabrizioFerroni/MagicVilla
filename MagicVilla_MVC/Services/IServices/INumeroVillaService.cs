using MagicVilla_MVC.Models.Dto;

namespace MagicVilla_MVC.Services.IServices
{
    public interface INumeroVillaService
    {
        Task<T> ObtenerTodos<T>();
        Task<T> Obtener<T>(string id);
        Task<T> Crear<T>(NumeroVillaCreateRequest dto);
        Task<T> Actualizar<T>(NumeroVillaUpdateRequest dto);
        // Task<T> Remover<T>(string id);
        Task<T> Remover<T>(int VillaNro);
    }
}
