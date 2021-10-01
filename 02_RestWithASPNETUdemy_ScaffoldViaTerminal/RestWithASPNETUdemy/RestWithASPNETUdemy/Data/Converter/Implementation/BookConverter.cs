using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Data.Converter.Implementation
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {

        public Book Parser(BookVO origin)
        {
            if (origin == null) return null;

            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_Date = origin.Launch_Date,
                Price = origin.Price,
                Title = origin.Title
            };
        }
        public BookVO Parser(Book origin)
        {
            if (origin == null) return null;

            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_Date = origin.Launch_Date,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parser(List<BookVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parser(item)).ToList();
        }

        public List<BookVO> Parser(List<Book> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
