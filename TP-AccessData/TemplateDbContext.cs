using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Entities;

namespace TP_AccessData
{
   public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {

        }

        public DbSet<Turno> Turnos { get; set; }
        public DbSet<CalendarioTurnos> CalendarioTurnos { get; set; }
        public DbSet<Dia> Dias { get; set; }
    }
}
