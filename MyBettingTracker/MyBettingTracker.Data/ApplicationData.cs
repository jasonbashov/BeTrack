namespace MyBettingTracker.Data
{
    using System;
    using System.Collections.Generic;

    using Common.Contracts;
    using Contracts;
    using Models;
    using Repository;

    public class ApplicationData : IApplicationData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData(ApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }


        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetDeletableEntityRepository<ApplicationUser>();
            }
        }

        public IApplicationDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
