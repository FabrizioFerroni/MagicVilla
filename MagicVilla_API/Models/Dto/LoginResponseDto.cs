namespace MagicVilla_API.Models.Dto
{
    public class LoginResponseDto
    {
        public Usuario usuario { get; set; }
        public string Token { get; set; } = "";
    }
}
