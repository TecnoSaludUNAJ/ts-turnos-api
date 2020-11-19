using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Domain.DTOs
{
    public class CalendarioPost
    {
        public int IdEspecialista { get; set; }
        public int DiaId { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

    }
}
