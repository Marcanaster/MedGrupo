using MedGrupo.Domain.Entities.ValueObjects;
using System;

namespace MedGrupo.Domain.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Nome Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
