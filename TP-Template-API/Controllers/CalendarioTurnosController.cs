using Microsoft.AspNetCore.Mvc;
using System;
using TP_Application.Services;
using TP_Domain.DTOs;

namespace TP_Template_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarioTurnosController:ControllerBase
    {
        private readonly ICalendarioTurnosService _service;
        public CalendarioTurnosController(ICalendarioTurnosService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(CalendarioTurnosDto calendarioTurnos)
        {
            try
            {
                return new JsonResult(_service.CreateCalendarioTurnos(calendarioTurnos)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(_service.GetAllCalendarioTurnos()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
