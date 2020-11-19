using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class RequestTurnoDto
    {
        public int IdEspecialista { get; set; }
        public int IdPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
    }
}
