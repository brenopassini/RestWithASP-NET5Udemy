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

        public BookBusinessImplementation(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book Create(Book book)
        {
            return this._bookRepository.Create(book);
        }

        public void Delete(long id)
        {
            this._bookRepository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _bookRepository.FindAll().ToList();
        }

        public Book FindByID(long id)
        {
            return this._bookRepository.FindByID(id);
        }

        public Book Update(Book book)
        {
            this._bookRepository.Update(book);
            return book;
        }
    }
}
