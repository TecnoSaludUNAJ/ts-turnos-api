using Microsoft.AspNetCore.Mvc;
using System;
using TP_Application.Services;
using TP_Domain.DTOs;

namespace TP_Template_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosDisponiblesController:ControllerBase
    {
        private readonly ITurnoService _service;
        public TurnosDisponiblesController(ITurnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] DateTime fecha, [FromQuery] int IdEspecialista)
        {
            try
            {
                return new JsonResult(_service.GetAllTurnosDisponibles(fecha, IdEspecialista)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
