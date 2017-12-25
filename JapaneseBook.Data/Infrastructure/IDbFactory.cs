using System;

namespace JapaneseBook.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        JapaneseBookDbContext Init();
    }
}