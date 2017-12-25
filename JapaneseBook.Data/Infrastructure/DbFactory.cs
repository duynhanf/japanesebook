namespace JapaneseBook.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private JapaneseBookDbContext dbContext;

        public JapaneseBookDbContext Init()
        {
            return dbContext ?? (dbContext = new JapaneseBookDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}