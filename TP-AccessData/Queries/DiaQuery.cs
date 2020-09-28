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
    public class DiaQuery : IDiaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public DiaQuery (IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public Dia GetById(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Dias")
                .Where("Id", "=", id);

            return query.FirstOrDefault<Dia>();
        }
    }
}
