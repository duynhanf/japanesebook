namespace JapaneseBook.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}