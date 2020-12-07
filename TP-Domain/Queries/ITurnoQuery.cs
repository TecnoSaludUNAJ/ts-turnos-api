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
        List<ResponseTurnoDto> GetTurnosEspecialista(int IdEspecialista, int especialidad, DateTime fecha);
        Turno GetTurnoExistente(int IdEspecialista, int IdEspecialidad, DateTime fecha, DateTime horaInicio);
    }
}
