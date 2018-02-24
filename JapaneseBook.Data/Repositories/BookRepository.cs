using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Model.Entities;
using System;
using System.Collections.Generic;

namespace JapaneseBook.Data.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow);
    }

    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Book> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }
    }
}