using MedGrupo.Domain.Entities.ValueObjects;
using MedGrupo.Domain.Enums;
using System;

namespace MedGrupo.Domain.Dtos.Contact
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool Active { get; set; }
    }
}
