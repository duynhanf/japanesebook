using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Model.Entities;

namespace JapaneseBook.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory x_objDbFactory) : base(x_objDbFactory)
        {
        }
    }
}