using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseBook.Data.Repositories
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {

    }

    public class BookCategoryRepository : RepositoryBase<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
