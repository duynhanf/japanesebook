using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Model.Entities;

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