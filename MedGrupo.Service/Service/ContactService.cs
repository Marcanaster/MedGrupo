using AutoMapper;
using MedGrupo.Domain.Dtos.Contact;
using MedGrupo.Domain.Entities;
using MedGrupo.Domain.Interfaces.Repositories;
using MedGrupo.Domain.Interfaces.Services.Contact;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedGrupo.Service.Service
{
    public class ContactService : IContactService
    {
        private IRepository<ContactEntity> _repository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<ContactEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ContactEntity> Get(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<ContactEntity>> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ContactEntity> Post(ContactDto contact)
        {
            var entity = _mapper.Map<ContactEntity>(contact);
            return await _repository.InsertAsync(entity);
        }

        public async Task<ContactEntity> Put(ContactDto contact)
        {
            var entity = _mapper.Map<ContactEntity>(contact);
            return await _repository.UpdateAsync(entity);
        }
    }
}
