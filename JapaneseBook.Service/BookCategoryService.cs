using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Data.Repositories;
using JapaneseBook.Model.Entities;

namespace JapaneseBook.Service
{
    /// <summary>
    ///
    /// </summary>
    public interface IBookCategoryService
    {
        BookCategory Add(BookCategory x_objBookCategory);
    }

    /// <summary>
    ///
    /// </summary>
    public class BookCategoryService : IBookCategoryService
    {
        private IBookCategoryRepository m_objBookCategoryRepository;                    //object BookRepository
        private IUnitOfWork m_objUnitOfWork;                                            //object UnitOfWork

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x_objBookCategoryRepository"></param>
        /// <param name="x_objUnitOfWork"></param>
        public BookCategoryService(IBookCategoryRepository x_objBookCategoryRepository, IUnitOfWork x_objUnitOfWork)
        {
            this.m_objBookCategoryRepository = x_objBookCategoryRepository;
            this.m_objUnitOfWork = x_objUnitOfWork;
        }

        /// <summary>
        /// Add Bookcategory
        /// </summary>
        /// <param name="x_objBookCategory"></param>
        /// <returns></returns>
        public BookCategory Add(BookCategory x_objBookCategory)
        {
            return m_objBookCategoryRepository.Add(x_objBookCategory);
        }
    }
}