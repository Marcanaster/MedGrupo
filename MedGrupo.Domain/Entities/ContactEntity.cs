using MedGrupo.CrossCutting.Helper;
using MedGrupo.Domain.Entities.Base;
using MedGrupo.Domain.Entities.ValueObjects;
using MedGrupo.Domain.Enums;
using MedGrupo.Domain.Validation;
using System;

namespace MedGrupo.Domain.Entities
{
    public class ContactEntity : BaseEntity
    {
        public ContactEntity()
        {
            this.Active = true;
        }

        public ContactEntity(string name, DateTime dateOfBirth, GenderEnum gender, bool active)
        {
            ValidationDomain(name, dateOfBirth, gender, active);
        }


        public string Nome { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public bool Active { get; set; }
        private void ValidationDomain(string name, DateTime dateOfBirth, GenderEnum gender, bool active)
        {
            DomainExceptionValidation.When(name == null, "O nome é obrigatório. ");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome é obrigatório. ");
            DomainExceptionValidation.When((Util.CalculaIdade(dateOfBirth, DateTime.Now) < 18), "O contato não pode ser menor de idade");

            Nome = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Active = active;

        }
    }
}
