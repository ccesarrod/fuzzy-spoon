using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NorthWindCoreData
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IUnitOfWork _unitOfWork;
        private DbContext _dbcontext;
       // private IDbContext _container;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           // _container = _unitOfWork.Container;
            _dbcontext = unitOfWork.Container;
            
        }

        public IDbSet<TEntity> DbSet
        {
            get
            {
               
                return _dbcontext.Set<TEntity>();
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> expresion)
        {
            var x = GetAll().ToList();
            return x.Where(expresion).AsQueryable();
        }

        public void Delete(TEntity entity)
        {
         
           
            var entityObject = _dbcontext.Entry(entity);
            if (entityObject.State != EntityState.Deleted)
            {
                entityObject.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Remove(entity);
            }
        }
        public void Add(TEntity entity)
        {
            var entityObject = _dbcontext.Entry(entity);
            if (entityObject.State != EntityState.Detached)
            {
                entityObject.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
          
        }

        public void Update(TEntity entity)
        {
    
            var entry = _dbcontext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {

                DbSet.Attach(entity);

            }
           
            //_dbcontext.db
            entry.State = EntityState.Modified;
        
           
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_unitOfWork != null)
                {
                   _unitOfWork.Dispose();
                   
                }
            }
        }



    }
}