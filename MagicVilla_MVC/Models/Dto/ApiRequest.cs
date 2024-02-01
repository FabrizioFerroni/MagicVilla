using static MagicVilla_Utils.DS;

namespace MagicVilla_MVC.Models.Dto
{
    public class ApiRequest
    {
        public ApiTipo ApiTipo { get; set; } = ApiTipo.GET;
        public String Url { get; set; } = "";
        public object Datos { get; set; } = "";
        public string Token { get; set; } = "";
    }
}
