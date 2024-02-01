﻿using AutoMapper;
using MagicVilla_MVC.Models.Dto;
using MagicVilla_MVC.Services.IServices;
using MagicVilla_Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MagicVilla_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(ILogger<HomeController> logger, IUsuarioService usuarioService, IMapper mapper)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDto dto)
        {
            var response = await _usuarioService.Login<ApiResponse>(dto);

            if(response != null && response.IsSuccess)
            {
                LoginResponseDto objeto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Data));

                //Claims 
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim(ClaimTypes.Name, objeto.Usuario.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, objeto.Usuario.Rol));

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //Session
                HttpContext.Session.SetString(DS.SessionToken, objeto.Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("ErrorMensaje", response.ErrorMensaje.FirstOrDefault());
                return View(dto);
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistroRequestDto dto)
        {
            var response = await _usuarioService.Register<ApiResponse>(dto);

            if(response != null && response.IsSuccess)
            {
                return RedirectToAction("login");
            }
            return View(dto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(DS.SessionToken, "");
            return RedirectToAction("login");
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
