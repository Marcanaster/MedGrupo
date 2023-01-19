using System;
using System.ComponentModel.DataAnnotations;

namespace MedGrupo.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; protected set; }

        private DateTime? _createAt;

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public DateTime? CreatAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? UpdateAt { get; set; }

        public void Create(Guid id)
        {
            Id = id;
        }
    }
}
