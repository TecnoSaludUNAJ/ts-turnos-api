using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class ResponseTurnoDto
    {
        public int? Id { get; set; }
        public int IdEspecialista { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdConsultorio { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
