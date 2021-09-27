using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private SqlServerContext _context;

        public PersonServiceImplementation(SqlServerContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            this._context.Add(person);
            this._context.SaveChanges();
            return person;
        }

        public void Delete(long id)
        {
            Person person = this._context.Persons.Where(o => o.Id == id).FirstOrDefault();
            this._context.Remove(person);
            this._context.SaveChanges();
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByID(long id)
        {
            return this._context.Persons.Where(o => o.Id == id).FirstOrDefault();
        }

        public Person Update(Person person)
        {
            this._context.Update(person);
            this._context.SaveChanges();
            return person;
        }
    }
}
