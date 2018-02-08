using JapaneseBook.Data.Infrastructure;
using JapaneseBook.Model.Entities;
using JapaneseBook.Data.Repositories;
using System.Collections.Generic;
using System;

namespace JapaneseBook.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x_objBook"></param>
        /// <returns></returns>
        Book Add(Book x_objBook);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x_iBookID"></param>
        /// <returns></returns>
        Book Delete(int x_iBookID);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x_iBookID"></param>
        /// <returns></returns>
        Book GetBookDetail(int x_iBookID);

    }

    /// <summary>
    /// implement of IBookService
    /// </summary>
    public class BookService : IBookService
    {
        private IBookRepository m_objBookRepository;                    //object BookRepository

        private IUnitOfWork m_objUnitOfWork;                            //object UnitOfWork
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x_objBookRepository"></param>
        /// <param name="x_objUnitOfWork"></param>
        public BookService(IBookRepository x_objBookRepository, IUnitOfWork x_objUnitOfWork)
        {
            this.m_objBookRepository = x_objBookRepository;
            this.m_objUnitOfWork = x_objUnitOfWork;
        }
        
        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="x_objBook"></param>
        /// <returns></returns>
        public Book Add(Book x_objBook)
        {
            var objBook = m_objBookRepository.Add(x_objBook);
            m_objUnitOfWork.Commit();
            
            return objBook;
        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="x_iBookID"></param>
        /// <returns></returns>
        public Book Delete(int x_iBookID)
        {
            Book objBook = m_objBookRepository.GetSingleById(x_iBookID);

            return m_objBookRepository.Delete(objBook);
        }

        /// <summary>
        /// Get all book
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get detail book by id
        /// </summary>
        /// <param name="x_iBookID"></param>
        /// <returns></returns>
        public Book GetBookDetail(int x_iBookID)
        {
            return m_objBookRepository.GetSingleById(x_iBookID);
        }

    }
}