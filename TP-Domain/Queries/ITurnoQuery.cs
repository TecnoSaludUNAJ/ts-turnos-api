using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Domain.Queries
{
    public interface ITurnoQuery
    {
        List<ResponseTurnoDto> GetAllTurnos(int IdPaciente);
        List<Turno> GetTurnosDelDia(DateTime fecha, int IdEspecialidad);
        ResponseTurnoDto GetById(string id);
    }
}
