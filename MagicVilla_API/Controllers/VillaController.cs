﻿using Microsoft.AspNetCore.Mvc;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using MagicVilla_API.Models;
using AutoMapper;
using MagicVilla_API.Repositories.IRepositories;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly IVillaRepository _villaRepo;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public VillaController(ILogger<VillaController> logger, IVillaRepository villaRepo, IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetVillas()
        {
            try
            {
                IEnumerable<Villa> villaList = await _villaRepo.ObtenerTodos();
                var mapper = _mapper.Map<IEnumerable<VillaDto>>(villaList);
                _logger.LogInformation("Se obtuvieron todas las villas");
                _response.Data = mapper;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMensaje = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetVilla(Guid id)
        {
            try
            {
                var villa = await _villaRepo.Obtener(v => v.Id.Equals(id), true);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMensaje = new List<string>() { "Villa no encontrada, no hubieron coincidencias" }; 
                    return NotFound(_response);
                }

                var mapper = _mapper.Map<VillaDto>(villa);

                _response.Data = mapper;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (System.Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMensaje = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> CreateVilla([FromBody] VillaCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    // _response.ErrorMensaje = new List<String>() {  };
                    _response.Data = ModelState;
                    return BadRequest(_response);
                }

                if (await _villaRepo.Obtener(v => v.Nombre.ToLower() == dto.Nombre.ToLower(), false) != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMensaje = new List<string>() { "La villa con ese nombre ya existe" };
                    return BadRequest(_response);
                }

                if (dto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMensaje = new List<string>() { "No se ha enviado una villa" };
                    return BadRequest(_response);
                }

                Villa villa = _mapper.Map<Villa>(dto);
                villa.FechaCreacion = DateTime.Now;
                villa.FechaActualizacion = DateTime.Now;

                await _villaRepo.Crear(villa);

                _response.Data = "Villa creada con éxito.";
                _response.StatusCode = HttpStatusCode.Created;

                return StatusCode(StatusCodes.Status201Created, _response);
            }
            catch (System.Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMensaje = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateVilla(Guid id, [FromBody] VillaUpdateDto dto)
        {
            try
            {
                if (dto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMensaje = new List<string>() { "No has enviado datos" };
                    return BadRequest(_response);
                }

                var villa = await _villaRepo.Obtener(v => v.Id.Equals(id), false);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMensaje = new List<string>() { "Villa no encontrada, no hubieron coincidencias" };
                    return NotFound(_response);
                }

                dto.Id = id;
                Villa modelo = _mapper.Map<Villa>(dto);

                modelo.FechaCreacion = villa.FechaCreacion;
                modelo.FechaActualizacion = DateTime.Now;

                await _villaRepo.Actualizar(modelo);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Data = "Villa actualizada con exito";

                return Ok(_response);
            }
            catch (System.Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMensaje = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePartialVilla(Guid id, JsonPatchDocument<VillaUpdateDto> patchDocument)
        {
            try
            {
                var villa = await _villaRepo.Obtener(v => v.Id.Equals(id), false);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMensaje = new List<string>() { "Villa no encontrada, no hubieron coincidencias" }; 
                    return NotFound(_response);
                }

                VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);

                patchDocument.ApplyTo(villaDto, ModelState);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    // _response.ErrorMensaje = new List<String>() {  };
                    _response.Data = ModelState;
                    return BadRequest(_response);
                }

                Villa modelo = _mapper.Map<Villa>(villaDto);

                modelo.FechaCreacion = villa.FechaCreacion;
                modelo.FechaActualizacion = DateTime.Now;

                await _villaRepo.Actualizar(modelo);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Data = "Villa actualizada con exito";

                return Ok(_response);
            }
            catch (System.Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMensaje = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteVilla(Guid id)
        {
            try
            {
                var villa = await _villaRepo.Obtener(v => v.Id.Equals(id), true);

                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMensaje = new List<string>() { "Villa no encontrada, no hubieron coincidencias" };
                    return NotFound(_response);
                }

                await _villaRepo.Remover(villa);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Data = "Villa borrada con éxito";

                return Ok(_response);
            }
            catch (System.Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMensaje = new List<string>() { ex.ToString() };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}