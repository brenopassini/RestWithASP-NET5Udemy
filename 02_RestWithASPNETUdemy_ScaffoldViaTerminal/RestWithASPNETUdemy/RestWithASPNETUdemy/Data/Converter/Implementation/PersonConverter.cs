using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {

        public Person Parser(PersonVO origin)
        {
            if (origin == null) return null;

            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }
        public PersonVO Parser(Person origin)
        {
            if (origin == null) return null;

            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> Parser(List<PersonVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parser(item)).ToList();
        }

        public List<PersonVO> Parser(List<Person> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
