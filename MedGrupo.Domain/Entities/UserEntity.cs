using MedGrupo.Domain.Entities.Base;
using MedGrupo.Domain.Validation;

namespace MedGrupo.Domain.Entities
{
    public sealed class UserEntity : BaseEntity
    {
        public UserEntity()
        {
            Active = true;

        }
        public UserEntity(string login, string senha, string nome, bool ativo, string email)
        {
            ValidationDomain(login, senha, nome, ativo, email);
        }

        public void Update(string login, string password, string name, bool active, string email)
        {
            Login = login;
            Password = password;
            Nome = name;
            Email = email;
            Active = active;
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }

        private void ValidationDomain(string login, string password, string name, bool active, string email)
        {
            DomainExceptionValidation.When(name == null, "O nome é obrigatório. ");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O nome é obrigatório. ");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(login), "O login é obrigatório. ");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(password), "A senha é obrigatória. ");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "O e-mail é obrigatória. ");
            Login = login;
            Password = password;
            Nome = name;
            Email = email;
            Active = active;
        }
    }
}
