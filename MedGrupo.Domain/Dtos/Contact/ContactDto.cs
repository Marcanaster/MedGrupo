using System;

namespace MedGrupo.Domain.Dtos.Contact
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool Active { get; set; }
    }
}
