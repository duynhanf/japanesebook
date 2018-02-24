using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace JapaneseBook.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties

        private JapaneseBookDbContext m_objJapaneseBookDbContext;
        private readonly IDbSet<T> m_objDbSet;

        protected IDbFactory m_objDbFactory
        {
            get;
            private set;
        }

        protected JapaneseBookDbContext DbContext
        {
            get { return m_objJapaneseBookDbContext ?? (m_objJapaneseBookDbContext = m_objDbFactory.Init()); }
        }

        #endregion Properties

        protected RepositoryBase(IDbFactory x_objDbFactory)
        {
            m_objDbFactory = x_objDbFactory;
            m_objDbSet = DbContext.Set<T>();
        }

        #region Implementation

        public virtual T Add(T x_TEntity)
        {
            return m_objDbSet.Add(x_TEntity);
        }

        public virtual void Update(T x_TEntity)
        {
            m_objDbSet.Attach(x_TEntity);
            m_objJapaneseBookDbContext.Entry(x_TEntity).State = EntityState.Modified;
        }

        public virtual T Delete(T x_TEntity)
        {
            return m_objDbSet.Remove(x_TEntity);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = m_objDbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                m_objDbSet.Remove(obj);
        }

        public virtual T GetSingleById(int x_iID)
        {
            return m_objDbSet.Find(x_iID);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        {
            return m_objDbSet.Where(where).ToList();
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return m_objDbSet.Count(where);
        }

        public IQueryable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = m_objJapaneseBookDbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return m_objJapaneseBookDbContext.Set<T>().AsQueryable();
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            return GetAll(includes).FirstOrDefault(expression);
        }

        public virtual IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = m_objJapaneseBookDbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return m_objJapaneseBookDbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = m_objJapaneseBookDbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = predicate != null ? m_objJapaneseBookDbContext.Set<T>().Where<T>(predicate).AsQueryable() : m_objJapaneseBookDbContext.Set<T>().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return m_objJapaneseBookDbContext.Set<T>().Count<T>(predicate) > 0;
        }

        #endregion Implementation
    }
}