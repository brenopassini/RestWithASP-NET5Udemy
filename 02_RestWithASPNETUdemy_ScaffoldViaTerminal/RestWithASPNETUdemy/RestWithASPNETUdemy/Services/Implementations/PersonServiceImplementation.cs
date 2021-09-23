using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = i,
                FirstName = "Breno" + i,
                LastName = "Medeiros" + i,
                Address = "BH" + i,
                Gender = "M"
            };
        }

        public Person FindByID(long id)
        {
            return new Person()
            {
                Id = 1,
                FirstName = "Breno" + id,
                LastName = "Medeiros",
                Address = "BH",
                Gender = "M"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
