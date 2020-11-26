using System;
using System.ComponentModel.DataAnnotations;

namespace TP_Domain.Entities
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        public int IdEspecialista { get; set; }
        public int IdEspecialidad { get; set; }
        public int IdPaciente { get; set; }
        public int IdConsultorio { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
    }
}
