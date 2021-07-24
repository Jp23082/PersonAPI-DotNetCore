using AutoMapper;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly IMapper mapper;


        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository, IMapper mapper)
        {
            this._personPhoneRepository = personPhoneRepository;
            this.mapper = mapper;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public List<PersonPhoneViewModel> Get()
        {
            List<PersonPhoneViewModel> _personPhoneModels = new List<PersonPhoneViewModel>();

            IEnumerable <PersonPhone> _personPhone = this._personPhoneRepository.GetAll();

            _personPhoneModels = mapper.Map<List<PersonPhoneViewModel>>(_personPhone);

            return _personPhoneModels;
        }

        public bool Post(PersonPhoneViewModel personPhoneViewModel)
        {
            PersonPhone _personPhone = mapper.Map<PersonPhone>(personPhoneViewModel);

            this._personPhoneRepository.Create(_personPhone);

            return true;
        }

        //Retorna um Person Phone filtrado pelo Id
        public PersonPhoneViewModel GetByBusinessEntityID(string id)
        {
            if (!int.TryParse(id, out int personPhoneId))
                throw new Exception("Person Phone Id not valid");

            PersonPhone _personPhone = this._personPhoneRepository.Find(x => x.BusinessEntityID == personPhoneId);
            if (_personPhone == null)
                throw new Exception("Person Phone not found");

            return mapper.Map<PersonPhoneViewModel>(_personPhone);
        }

        //Altera um Person Phone
        public bool Put(PersonPhoneViewModel personPhoneViewModel)
        {
            PersonPhone _personPhone = this._personPhoneRepository.Find(x => x.BusinessEntityID == personPhoneViewModel.BusinessEntityID);
            if (_personPhone == null)
                throw new Exception("Person Phone not found");

            _personPhone = mapper.Map<PersonPhone>(personPhoneViewModel);

            this._personPhoneRepository.Update(_personPhone);
            return true;
        }

        //Deletar um Person Phone
        public bool Delete(string id)
        {
            if (!int.TryParse(id, out int personPhoneId))
                throw new Exception("Person Phone Id not valid");

            PersonPhone _personPhone = this._personPhoneRepository.Find(x => x.BusinessEntityID == personPhoneId);
            if (_personPhone == null)
                throw new Exception("Person Phone not found");

            return this._personPhoneRepository.Delete(_personPhone); ;
        }
    }
}
