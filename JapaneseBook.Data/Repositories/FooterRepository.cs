using System.Collections.Generic;
using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Model.Models;

namespace JapaneseBook.Data.Repositories
{
    public interface IFooterRepository
    {
        IEnumerable<Footer> GetByAlias(string alias);
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Footer> GetByAlias(string alias)
        {
            //return this.DbContext..Where(x => x.Alias == alias);
            return null;
        }
    }
}