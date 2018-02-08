using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
