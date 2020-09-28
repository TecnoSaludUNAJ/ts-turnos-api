using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Entities;

namespace TP_Domain.Queries
{
    public interface IDiaQuery
    {
        Dia GetById(int id);
    }
}
