using MedGrupo.Domain.Entities.Base;
using MedGrupo.Domain.Entities.ValueObjects;
using MedGrupo.Domain.Validation;

namespace MedGrupo.Domain.Entities
{
    public sealed class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            Ativo = true;

        }
        public UserEntity(string login, string senha, Nome nome, bool ativo, string email)
        {
            ValidationDomain(login, senha, nome, ativo, email);
        }

        public void Update(string login, string senha, Nome nome, bool ativo, string email)
        {
            Login = login;
            Senha = senha;
            Nome = nome;
            Email = email;
            Ativo = ativo;
        }

        public string Login { get; private set; }
        public string Senha { get; private set; }
        public Nome Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        private void ValidationDomain(string login, string senha, Nome nome, bool ativo, string email)
        {
            DomainExceptionValidation.When(nome == null, "O nome é obrigatório. ");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome.FirstName), "O nome é obrigatório. ");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome.LastName), "O sobrenome é obrigatório. ");
            DomainExceptionValidation.When(nome.FirstName.Length < 3, "O nome precisa ter no minimo 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(login), "O login é obrigatório. ");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(senha), "A senha é obrigatória. ");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "O e-mail é obrigatória. ");
            Login = login;
            Senha = senha;
            Nome = nome;
            Email = email;
            Ativo = ativo;
        }
    }
}
