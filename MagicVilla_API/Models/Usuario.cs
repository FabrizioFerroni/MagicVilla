using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MagicVilla_API.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = new Guid();
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string UserName { get; set; } = "";
        [JsonIgnore]
        public string Password { get; set; } = "";
        public string Rol { get; set; } = "";
    }
}
