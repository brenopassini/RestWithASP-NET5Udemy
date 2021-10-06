using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO FindByID(long id);

        List<PersonVO> FindByName(string firstName, string lastName);

        PersonVO Update(PersonVO person);

        void Delete(long id);

        PersonVO Disable(long id);

        List<PersonVO> FindAll();
    }
}
