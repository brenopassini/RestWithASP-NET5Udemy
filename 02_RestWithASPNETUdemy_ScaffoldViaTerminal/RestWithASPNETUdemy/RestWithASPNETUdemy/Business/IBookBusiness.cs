using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);

        BookVO FindByID(long id);

        BookVO Update(BookVO book);

        void Delete(long id);

        List<BookVO> FindAll();
    }
}
