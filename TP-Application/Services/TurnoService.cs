using System;
using System.Collections.Generic;
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
    }
    public class TurnoService : ITurnoService
    {
        private readonly IGenericRepository _repository;
        private readonly ITurnoQuery _query;
        public TurnoService(IGenericRepository repository, ITurnoQuery query)
        {
            _repository = repository;
            _query = query;
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

        public ResponseTurnoDto GetById(string id)
        {
            return _query.GetById(id);
        }
    }
}
