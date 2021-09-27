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

        public PersonBusinessImplementation(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person Create(Person person)
        {
            return this._personRepository.Create(person);
        }

        public void Delete(long id)
        {
            this._personRepository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _personRepository.FindAll().ToList();
        }

        public Person FindByID(long id)
        {
            return this._personRepository.FindByID(id);
        }

        public Person Update(Person person)
        {
            this._personRepository.Update(person);
            return person;
        }
    }
}
