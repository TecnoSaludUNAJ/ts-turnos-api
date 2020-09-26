using Microsoft.AspNetCore.Mvc;
using System;
using TP_Application.Services;
using TP_Domain.DTOs;

namespace TP_Template_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController:ControllerBase
    {
        private readonly ITurnoService _service;
        public TurnosController(ITurnoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(TurnoDto alumno)
        {
            try
            {
                return new JsonResult(_service.CreateTurno(alumno)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
