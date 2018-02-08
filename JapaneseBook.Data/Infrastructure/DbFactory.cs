namespace JapaneseBook.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private JapaneseBookDbContext m_objJapaneseBookDbContext;

        public JapaneseBookDbContext Init()
        {
            return m_objJapaneseBookDbContext ?? (m_objJapaneseBookDbContext = new JapaneseBookDbContext());
        }

        protected override void DisposeCore()
        {
            if (m_objJapaneseBookDbContext != null)
                m_objJapaneseBookDbContext.Dispose();
        }
    }
}