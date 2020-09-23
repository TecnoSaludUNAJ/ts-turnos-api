using System;

namespace TP_Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}