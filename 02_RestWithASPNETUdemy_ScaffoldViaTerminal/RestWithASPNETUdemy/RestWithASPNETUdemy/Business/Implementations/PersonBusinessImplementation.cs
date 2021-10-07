using RestWithASPNETUdemy.Data.Converter.Implementation;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Utils;
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

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.ToLower().Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;
            string countQuery = "select count(*) from person p where 1=1 ";

            string query = @"select * from person p where 1=1 ";
            if (!string.IsNullOrWhiteSpace(name))
            {
                query += $"and p.first_name like '%{name}%'";
            }

            query += $"order by p.first_name {sort} offset {offset} ROWS FETCH NEXT {size} ROWS ONLY";

            if (!string.IsNullOrWhiteSpace(name))
            {
                countQuery += $"and p.first_name like '%{name}%'";
            }

            var persons = _personRepository.FindWithPagedSearch(query);
            int totalResults = _personRepository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = page,
                List = converter.Parser(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public PersonVO FindByID(long id)
        {
            return converter.Parser(this._personRepository.FindByID(id));
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return converter.Parser(_personRepository.FindByName(firstName, lastName));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = converter.Parser(person);
            personEntity = _personRepository.Update(personEntity);
            return converter.Parser(personEntity);
        }
    }
}
