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
        ResponseCalendarioTurnosDto CreateCalendarioTurnos(CalendarioTurnosDto calendarioTurno);
        List<CalendarioPost> GetAllCalendarioTurnos();

        CalendarioTurnos GetCalendarioEspecialistaEspecialidad(int DiaId, int IdEspecialidad, int IdEspecialista);
    }
    public class CalendarioTurnosService : ICalendarioTurnosService
    {
        private readonly IGenericRepository _repository;
        private readonly ICalendarioTurnosQuery _query;
        public CalendarioTurnosService(IGenericRepository repository, ICalendarioTurnosQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public ResponseCalendarioTurnosDto CreateCalendarioTurnos(CalendarioTurnosDto calendarioTurno)
        {
            List<CalendarioTurnos> Lista = new List<CalendarioTurnos>(){};

            foreach (var item in calendarioTurno.CalendarioTurnos)
            {
                
                CalendarioTurnos entity = new CalendarioTurnos
                {
                    IdEspecialidad = item.IdEspecialidad,
                    IdEspecialista = item.IdEspecialista,
                    DiaId = item.DiaId,
                    HoraInicio = Convert.ToDateTime(item.HoraInicio),
                    HoraFin = Convert.ToDateTime(item.HoraFin)
                };

                Lista.Add(entity);
                _repository.Add<CalendarioTurnos>(entity);
            }

            return new ResponseCalendarioTurnosDto {
                ListaCalendarioTurnos = Lista
            };
        }

        public List<CalendarioPost> GetAllCalendarioTurnos()
        {
            return _query.GetAllCalendarioTurnos();
        }

        public CalendarioTurnos GetCalendarioEspecialistaEspecialidad(int DiaId, int IdEspecialidad, int IdEspecialista)
        {
            return _query.GetCalendarioEspecialistaEspecialidad(DiaId, IdEspecialidad, IdEspecialista);
        }
    }
}
