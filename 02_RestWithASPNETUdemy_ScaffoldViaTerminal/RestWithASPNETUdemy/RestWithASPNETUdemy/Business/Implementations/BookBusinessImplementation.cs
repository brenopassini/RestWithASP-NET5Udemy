using RestWithASPNETUdemy.Data.Converter.Implementation;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter converter;

        public BookBusinessImplementation(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = converter.Parser(book);
            bookEntity = _bookRepository.Create(bookEntity);
            return converter.Parser(bookEntity);
        }

        public void Delete(long id)
        {
            this._bookRepository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return converter.Parser(_bookRepository.FindAll().ToList());
        }

        public BookVO FindByID(long id)
        {
            return converter.Parser(this._bookRepository.FindByID(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = converter.Parser(book);
            bookEntity = _bookRepository.Update(bookEntity);
            return converter.Parser(bookEntity);
        }
    }
}
