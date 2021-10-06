﻿using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(SqlServerContext contex) : base(contex)
        {

        }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id == id)) return null;

            var user = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (user != null)
            {
                user.Enabled = false;
            }

            try
            {
                _context.Entry(user).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return user;
        }
    }
}
