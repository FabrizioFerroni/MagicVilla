using MagicVilla_MVC.Models.Dto;

namespace MagicVilla_MVC.Services.IServices
{
    public interface IVillaService
    {
        Task<T> ObtenerTodos<T>() ;
        Task<T> Obtener<T>(string id);
        Task<T> Crear<T>(VillaCreateDto dto) ;
        Task<T> Actualizar<T>(VillaUpdateDto dto);
        Task<T> Remover<T>(string id) ;
    }
}
