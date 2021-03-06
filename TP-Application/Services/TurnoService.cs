﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_Application.Services
{
    public interface ITurnoService
    {
        Turno CreateTurno(RequestTurnoDto turno);
        List<ResponseTurnoDto> GetAllTurnos(int IdPaciente);
        ResponseTurnoDto GetById(string id);
        List<TurnosByHoursDto> GetAllTurnosDisponibles(DateTime fecha, int IdEspecialidad);
        List<ResponseTurnoDto> GetTurnosEspecialista(int IdEspecialista, int especialidad, DateTime fecha);
    }
    public class TurnoService : ITurnoService
    {
        private readonly IGenericRepository _repository;
        private readonly ITurnoQuery _query;
        private readonly ICalendarioTurnosQuery _calendarioTurnosQuery;
        public TurnoService(IGenericRepository repository, ITurnoQuery query, ICalendarioTurnosQuery calendarioTurnosQuery)
        {
            _repository = repository;
            _query = query;
            _calendarioTurnosQuery = calendarioTurnosQuery;
        }

        public Turno CreateTurno(RequestTurnoDto turno)
        {
            validateCrearTurno(turno);
            Turno entity = new Turno
            {
                IdEspecialista = turno.IdEspecialista,
                IdEspecialidad = turno.IdEspecialidad,
                IdPaciente = turno.IdPaciente,
                // #TODO: Change when implement the assigment of rooms
                IdConsultorio = 1,
                Fecha = turno.Fecha,
                HoraInicio = turno.HoraInicio,
                HoraFin = turno.HoraInicio.AddMinutes(30)
            };

            _repository.Add<Turno>(entity);
            
            return entity;
        }

        public void validateCrearTurno(RequestTurnoDto turno) {
            Turno turnoExistente = _query.GetTurnoExistente(turno.IdEspecialista, turno.IdEspecialidad, turno.Fecha, turno.HoraInicio);
            if (turnoExistente != null)
            {
                throw new Exception("El turno el cual intenta reservar ya está reservado.");
            }
        }

        public List<ResponseTurnoDto> GetAllTurnos(int IdPaciente)
        {
            return _query.GetAllTurnos(IdPaciente);
        }

        public List<TurnosByHoursDto> GetAllTurnosDisponibles(DateTime fecha, int IdEspecialidad)
        {
            List<TurnosByHoursDto> turnosByHours = new List<TurnosByHoursDto>() { };

            for (DateTime date = fecha; fecha.AddDays(4).Date.CompareTo(date.Date) >= 0; date = date.AddDays(1))
            {
                turnosByHours.Add(new TurnosByHoursDto () {
                    Fecha = date,
                    Turnos = GetTurnosDisponiblesByDay(date, IdEspecialidad)
                });
            }

            return turnosByHours;
        }

        public List<ResponseTurnoDto> GetTurnosDisponiblesByDay(DateTime fecha, int IdEspecialidad)
        {
            int dayId = GetDayId(fecha);

            List<Turno> turnosOcupados = _query.GetTurnosDelDia(fecha, IdEspecialidad);
            CalendarioTurnos diaDeAtencion = _calendarioTurnosQuery.GetCalendarioTurnoDeEspecialista(dayId, IdEspecialidad);

            if (diaDeAtencion == null)
            {
                return null;
            }

            List<ResponseTurnoDto> turnosDisponibles = new List<ResponseTurnoDto>();

            for (DateTime date = diaDeAtencion.HoraInicio; diaDeAtencion.HoraFin.CompareTo(date.AddMinutes(30)) >= 0; date = date.AddMinutes(30))
            {
                if (!IsTurnoOcupado(turnosOcupados, date))
                {
                    turnosDisponibles.Add(new ResponseTurnoDto()
                    {
                        IdEspecialidad = diaDeAtencion.IdEspecialidad,
                        IdEspecialista = diaDeAtencion.IdEspecialista,
                        Fecha = fecha,
                        HoraInicio = date,
                        HoraFin = date.AddMinutes(30),
                    });
                } else {
                    turnosDisponibles.Add(null);
                }
            }

            return turnosDisponibles;
        }

        public bool IsTurnoOcupado(List<Turno> turnosOcupados, DateTime horaDesde)
        {
            return turnosOcupados.Any(t => t.HoraInicio.Hour == horaDesde.Hour && t.HoraInicio.Minute == horaDesde.Minute);
        }

        public int GetDayId(DateTime fecha)
        {
            return ((int)fecha.DayOfWeek + 6) % 7 + 1;
        }

        public ResponseTurnoDto GetById(string id)
        {
            return _query.GetById(id);
        }

        public List<ResponseTurnoDto> GetTurnosEspecialista(int IdEspecialista, int especialidad, DateTime fecha)
        {
            return _query.GetTurnosEspecialista(IdEspecialista, especialidad, fecha);
        }
    }
}
