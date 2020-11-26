﻿using SqlKata.Compilers;
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
    public class CalendarioTurnosQuery : ICalendarioTurnosQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public CalendarioTurnosQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<CalendarioPost> GetAllCalendarioTurnos()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("CalendarioTurnos").SelectRaw("*");

            var result = query.Get<CalendarioPost>();

            return result.ToList();
        }

        public CalendarioTurnos GetCalendarioTurnoDeEspecialista(int DiaId, int IdEspecialidad)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("CalendarioTurnos")
                .Where("DiaId", "=", DiaId)
                .Where("IdEspecialidad", "=", IdEspecialidad);

            var result = query.Get<CalendarioTurnos>();

            return result.FirstOrDefault();
        }
    }
}
