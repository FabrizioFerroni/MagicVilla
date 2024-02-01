using MagicVilla_MVC.Models.Dto;

namespace MagicVilla_MVC.Services.IServices
{
    public interface IVillaService
    {
        Task<T> ObtenerTodos<T>(string token) ;
        Task<T> Obtener<T>(string id, string token);
        Task<T> Crear<T>(VillaCreateDto dto, string token) ;
        Task<T> Actualizar<T>(VillaUpdateDto dto, string token);
        Task<T> Remover<T>(string id, string token) ;
    }
}
