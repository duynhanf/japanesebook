using JapaneseBook.Data.Infrastructure;

namespace JapaneseBook.Service
{
    public interface IPostService
    {
    }

    public class PostService : IPostService
    {
        //private IBookRepository m_objBookRepository;                    //object BookRepository

        private IUnitOfWork m_objUnitOfWork;                            //
    }
}