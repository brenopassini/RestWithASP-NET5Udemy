using RestWithASPNETUdemy.Data.Converter.Implementation;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonConverter converter;

        public PersonBusinessImplementation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = converter.Parser(person);
            personEntity = _personRepository.Create(personEntity);
            return converter.Parser(personEntity);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _personRepository.Disable(id);
            return converter.Parser(personEntity);
        }

        public void Delete(long id)
        {
            this._personRepository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return converter.Parser(_personRepository.FindAll().ToList());
        }

        public PersonVO FindByID(long id)
        {
            return converter.Parser(this._personRepository.FindByID(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = converter.Parser(person);
            personEntity = _personRepository.Update(personEntity);
            return converter.Parser(personEntity);
        }
    }
}
