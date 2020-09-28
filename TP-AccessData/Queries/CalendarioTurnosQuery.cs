using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TP_Domain.DTOs;
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

        public List<ResponseCalendarioTurnosDto> GetAllCalendarioTurnos()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("CalendarioTurnos");

            var result = query.Get<ResponseCalendarioTurnosDto>();

            return result.ToList();
        }
    }
}
