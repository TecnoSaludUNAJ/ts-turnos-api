using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TP_Domain.Entities
{
    public class Dia
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
    }
}
