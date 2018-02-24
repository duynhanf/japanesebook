namespace JapaneseBook.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory m_objDbFactory;
        private JapaneseBookDbContext m_objJapaneseBookDbContext;

        public UnitOfWork(IDbFactory x_objDbFactory)
        {
            this.m_objDbFactory = x_objDbFactory;
        }

        public JapaneseBookDbContext DbContext
        {
            get { return m_objJapaneseBookDbContext ?? (m_objJapaneseBookDbContext = m_objDbFactory.Init()); }
        }

        /// <summary>
        /// Save to database
        /// </summary>
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}