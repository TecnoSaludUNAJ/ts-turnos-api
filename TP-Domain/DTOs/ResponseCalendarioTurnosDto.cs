using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using TP_Domain.Entities;

namespace TP_Domain.DTOs
{
    public class ResponseCalendarioTurnosDto
    {
       
        public List<CalendarioTurnos> ListaCalendarioTurnos { get; set; }
        
        
        
        
        //public int Id { get; set; }
        //public int DiaId { get; set; }
        //public int IdEspecialista { get; set; }
        //public DateTime HoraInicio { get; set; }
        //public DateTime HoraFin { get; set; }
    }
}
