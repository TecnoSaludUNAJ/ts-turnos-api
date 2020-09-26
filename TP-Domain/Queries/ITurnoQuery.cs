using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;

namespace TP_Domain.Queries
{
    public interface ITurnoQuery
    {
        List<ResponseTurnoDto> GetAllTurnos();
        ResponseTurnoDto GetById(string id);
    }
}
