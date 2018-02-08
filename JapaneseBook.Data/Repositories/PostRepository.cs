using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
