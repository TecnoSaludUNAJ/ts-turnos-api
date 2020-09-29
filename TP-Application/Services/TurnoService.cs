using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_Application.Services
{
    public interface ITurnoService
    {
        Turno CreateTurno(TurnoDto turno);
        List<ResponseTurnoDto> GetAllTurnos();
        ResponseTurnoDto GetById(string id);
        List<ResponseTurnoDto> GetAllTurnosDisponibles(DateTime fecha, int IdEspecialista);
    }
    public class TurnoService : ITurnoService
    {
        private readonly IGenericRepository _repository;
        private readonly ITurnoQuery _query;
        private readonly ICalendarioTurnosQuery _calendarioTurnosQuery;
        private readonly IDiaQuery _diaQuery;
        public TurnoService(IGenericRepository repository, ITurnoQuery query, ICalendarioTurnosQuery calendarioTurnosQuery, IDiaQuery diaQuery)
        {
            _repository = repository;
            _query = query;
            _calendarioTurnosQuery = calendarioTurnosQuery;
            _diaQuery = diaQuery;
        }

        public Turno CreateTurno(TurnoDto turno)
        {
            Turno entity = new Turno
            {
                IdEspecialista = turno.IdEspecialista,
                IdPaciente = turno.IdPaciente,
                IdConsultorio = turno.IdConsultorio,
                Fecha = DateTime.Today,
                HoraInicio = turno.HoraInicio,
                HoraFin = turno.HoraFin
            };

            _repository.Add<Turno>(entity);
            
            return entity;
        }

        public List<ResponseTurnoDto> GetAllTurnos()
        {
            return _query.GetAllTurnos();
        }

        public List<ResponseTurnoDto> GetAllTurnosDisponibles(DateTime fecha, int IdEspecialista)
        {
            int dayId = GetDayId(fecha);
            
            List<Turno> turnosOcupados = _query.GetTurnosDelDia(fecha);
            CalendarioTurnos diaDeAtencion = _calendarioTurnosQuery.GetCalendarioTurnoDeEspecialista(dayId, IdEspecialista);

            List<ResponseTurnoDto> turnosDisponibles = new List<ResponseTurnoDto>();

            for (DateTime date = diaDeAtencion.HoraInicio ; diaDeAtencion.HoraFin.CompareTo(date) >= 0; date = date.AddMinutes(30))
            {
                if (!IsTurnoOcupado(turnosOcupados, date))
                {
                    turnosDisponibles.Add(new ResponseTurnoDto() {
                        IdEspecialista = IdEspecialista,
                        Fecha = fecha,
                        HoraInicio = date,
                        HoraFin = date.AddMinutes(30),
                    });
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
    }
}
