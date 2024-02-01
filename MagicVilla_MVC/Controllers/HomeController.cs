using AutoMapper;
using MagicVilla_MVC.Models;
using MagicVilla_MVC.Models.Dto;
using MagicVilla_MVC.Services.IServices;
using MagicVilla_Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MagicVilla_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IVillaService villaService, IMapper mapper)
        {
            _logger = logger;
            _villaService = villaService;
            _mapper = mapper;
        }

        public async  Task<IActionResult> Index()
        {
            List<VillaDto> villaList = new();
            string token = HttpContext.Session.GetString(DS.SessionToken);

            var response = await _villaService.ObtenerTodos<ApiResponse>(token);

            if (response != null && response.IsSuccess)
            {
                villaList = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Data)!)!;
            }

            return View(villaList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}