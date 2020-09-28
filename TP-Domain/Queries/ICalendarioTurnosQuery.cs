using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;

namespace TP_Domain.Queries
{
    public interface ICalendarioTurnosQuery
    {
        List<ResponseCalendarioTurnosDto> GetAllCalendarioTurnos();
    }
}
