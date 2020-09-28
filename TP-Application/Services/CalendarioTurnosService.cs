using System;
using System.Collections.Generic;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_Application.Services
{
    public interface ICalendarioTurnosService
    {
        CalendarioTurnos CreateCalendarioTurnos(CalendarioTurnosDto calendarioTurno);
        List<ResponseCalendarioTurnosDto> GetAllCalendarioTurnos();
    }
    public class CalendarioTurnosService : ICalendarioTurnosService
    {
        private readonly IGenericRepository _repository;
        private readonly ICalendarioTurnosQuery _query;
        private readonly IDiaQuery _queryDia;
        public CalendarioTurnosService(IGenericRepository repository, ICalendarioTurnosQuery query, IDiaQuery queryDia)
        {
            _repository = repository;
            _query = query;
            _queryDia = queryDia;
        }

        public CalendarioTurnos CreateCalendarioTurnos(CalendarioTurnosDto calendarioTurno)
        {
            Dia dia = _queryDia.GetById(calendarioTurno.IdDia);

            CalendarioTurnos entity = new CalendarioTurnos
            {
                IdEspecialista = calendarioTurno.IdEspecialista,
                Dia = dia,
                HoraInicio = calendarioTurno.HoraInicio,
                HoraFin = calendarioTurno.HoraFin
            };

            _repository.Add<CalendarioTurnos>(entity);
            
            return entity;
        }

        public List<ResponseCalendarioTurnosDto> GetAllCalendarioTurnos()
        {
            return _query.GetAllCalendarioTurnos();
        }
    }
}
