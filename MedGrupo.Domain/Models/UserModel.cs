using MedGrupo.Domain.Entities.ValueObjects;
using System;

namespace MedGrupo.Domain.Models
{
    public class UserModel
    {
        private Guid _id;

        public Guid id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _login;

        public string login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _email;

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        private Nome _nome;

        public Nome nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _senha;

        public string senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        private bool _ativo;

        public bool ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        private DateTime _creatAt;

        public DateTime createAt
        {
            get { return _creatAt; }
            set { _creatAt = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime _updateAt;

        public DateTime updateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
