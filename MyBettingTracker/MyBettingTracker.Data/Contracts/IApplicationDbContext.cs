namespace MyBettingTracker.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext
    {
        DbContext DbContext { get; }

        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}