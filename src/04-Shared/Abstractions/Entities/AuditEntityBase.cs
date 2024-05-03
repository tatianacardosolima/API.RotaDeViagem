using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RotaDeViagem.Shared.Interfaces.IEntities;

namespace RotaDeViagem.Shared.Abstractions.Entities
{
    public abstract class AuditEntityBase : IAuditableEntity
    {
        public long Id { get; set; }
        public Guid UniqueId { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        protected List<string> _errors = new List<string>();
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}
