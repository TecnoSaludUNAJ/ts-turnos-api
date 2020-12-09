using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_AccessData.Queries
{
    public class TurnoQuery : ITurnoQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public TurnoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseTurnoDto> GetAllTurnos(int IdPaciente)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("IdPaciente", "=", IdPaciente)
                .WhereDate("Fecha", ">=", DateTime.Now.ToString("MM-dd-yyyy"))
                .OrderBy("Fecha");

            var result = query.Get<ResponseTurnoDto>();


            return result.ToList();
        }

        public List<Turno> GetTurnosDelDia(DateTime fecha, int IdEspecialidad)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("IdEspecialidad", "=", IdEspecialidad)
                .Where("Fecha", "=", fecha);

            var result = query.Get<Turno>();

            return result.ToList();
        }

        public ResponseTurnoDto GetById(string id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("Id", "=", id);

            return query.FirstOrDefault<ResponseTurnoDto>();
        }

        public List<ResponseTurnoDto> GetTurnosEspecialista(int IdEspecialista, int especialidad, DateTime fecha)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("IdEspecialista", "=", IdEspecialista)
                // .Where("Fecha", "=", fecha.ToString("MM/dd/yyyy"))
                .Where("IdEspecialidad", "=", especialidad);
           
            return query
                .Get<ResponseTurnoDto>()
                .ToList();;
        }

        public Turno GetTurnoExistente(int IdEspecialista, int IdEspecialidad, DateTime fecha, DateTime horaInicio)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("IdEspecialista", "=", IdEspecialista)
                .WhereDate("Fecha", "=", fecha.ToString("MM-dd-yyyy"))
                .Where("IdEspecialidad", "=", IdEspecialidad)
                .WhereTime("HoraInicio", "=", horaInicio.ToString("HH:mm"));
            
            return query.FirstOrDefault<Turno>();
        }
    }
}
