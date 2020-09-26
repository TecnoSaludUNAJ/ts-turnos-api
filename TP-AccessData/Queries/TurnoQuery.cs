﻿using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP_Domain.DTOs;
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

        public List<ResponseTurnoDto> GetAllTurnos()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos");

            var result = query.Get<ResponseTurnoDto>();

            return result.ToList();
        }

        public ResponseTurnoDto GetById(string id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Turnos")
                .Where("Id", "=", id);

            return query.FirstOrDefault<ResponseTurnoDto>();
        }
    }
}