using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Domain.Queries
{
    public interface ITurnoQuery
    {
        List<ResponseTurnoDto> GetAllTurnos();
        List<Turno> GetTurnosDelDia(DateTime fecha);
        ResponseTurnoDto GetById(string id);
    }
}
