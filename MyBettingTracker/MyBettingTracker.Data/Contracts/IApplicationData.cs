namespace MyBettingTracker.Data
{
    using Contracts;
    using Models;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> Users { get; }
                
        IApplicationDbContext Context { get; }

        int SaveChanges();
    }
}
