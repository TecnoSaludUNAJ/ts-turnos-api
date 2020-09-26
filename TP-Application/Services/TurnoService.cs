using System;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Application.Services
{
    public interface ITurnoService
    {
        Turno CreateTurno(TurnoDto turno);
    }
    public class TurnoService : ITurnoService
    {
        private readonly IGenericRepository _repository;
        public TurnoService(IGenericRepository repository)
        {
            _repository = repository;
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
    }
}
