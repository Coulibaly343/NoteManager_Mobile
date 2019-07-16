using SQLite;
using System;

namespace NoteManager.Entities
{
    public class BaseEntity
    {
        [PrimaryKey] public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

    }
}
