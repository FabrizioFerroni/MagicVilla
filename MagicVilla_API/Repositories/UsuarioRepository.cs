using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VillaDbContext _db;
        private string secretKey;

        public UsuarioRepository(VillaDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUsuarioUnico(string username)
        {
            var usuario = _db.Usuarios.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());

            if (usuario != null)
            {
                return false;
            }

            return true;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            var usuario = await _db.Usuarios.FirstOrDefaultAsync(u => u.UserName.ToLower() == dto.UserName.ToLower() && u.Password == dto.Password);

            if (usuario == null)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    usuario = null
                };
            }

            // Si el usuario Existe Generamos el JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Rol)
                }),
                Expires= DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDto response = new()
            {
                Token = tokenHandler.WriteToken(token),
                usuario = usuario
            };

            return response;
        }

        public async Task<Usuario> Register(RegisterRequestDto dto)
        {
            Usuario usuario = new();

            usuario.UserName = dto.UserName;
            usuario.Password = dto.Password;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido= dto.Apellido;
            usuario.Rol = dto.Rol;

            await _db.Usuarios.AddAsync(usuario);
            await _db.SaveChangesAsync();

            return usuario;
        }
    }
}
