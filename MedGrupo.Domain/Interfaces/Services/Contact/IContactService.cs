using MedGrupo.Domain.Dtos.Contact;
using MedGrupo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Domain.Interfaces.Services.Contact
{
    public interface IContactService
    {
        Task<ContactEntity> Get(Guid id);
        Task<IEnumerable<ContactEntity>> GetAll();
        Task<ContactEntity> Post(ContactDto contact);
        Task<ContactEntity> Put(ContactDto contact);
        Task<bool> Delete(Guid id);
    }
}
