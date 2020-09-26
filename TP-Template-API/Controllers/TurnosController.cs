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
        public IActionResult Post(TurnoDto turno)
        {
            try
            {
                return new JsonResult(_service.CreateTurno(turno)) { StatusCode = 201 };
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
                return new JsonResult(_service.GetAllTurnos()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id?}")]
        public IActionResult GetById(string Id)
        {
            try
            {
                ResponseTurnoDto turno = _service.GetById(Id);
                if (turno != null)
                {
                    return new JsonResult(turno) { StatusCode = 200 };
                }
                return new JsonResult(turno) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
