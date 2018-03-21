using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Conectt.Repositories
{
    public class EfRepository<T> : IDisposable where T : class
    {
        protected ConecttContext DataContext;

        public EfRepository()
        {
        }

        public EfRepository(ConecttContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual void Add(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }

        public virtual int AddAndSave(T entity)
        {
            Add(entity);

            return DataContext.SaveChanges();
        }

        public virtual async Task<int> AddAndSaveAsync(T entity)
        {
            Add(entity);

            return await DataContext.SaveChangesAsync();
        }

        public virtual async Task<bool> DisableRelationship(string table, string constraint)
        {
            try
            {
                await DataContext.Database.ExecuteSqlCommandAsync(@"ALTER TABLE [dbo].[" + table + "] NOCHECK CONSTRAINT [" + constraint + "]");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual async Task<bool> EnableRelationship(string table, string constraint)
        {
            try
            {
                await DataContext.Database.ExecuteSqlCommandAsync(@"ALTER TABLE [dbo].[" + table + "] CHECK CONSTRAINT [" + constraint + "]");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public virtual void AttachAndUpdate(T entity)
        {
            DataContext.Entry(entity).State = EntityState.Modified;
            DataContext.Set<T>().Attach(entity);
        }

        public virtual async Task<int> AttachUpdateAndSaveAsync(T entity)
        {
            AttachAndUpdate(entity);

            return await DataContext.SaveChangesAsync();
        }

        public virtual void AttachAndUpdateOnField(T entity, string fieldName)
        {
            DataContext.Set<T>().Attach(entity);
            DataContext.Entry(entity).Property(fieldName).IsModified = true;
        }

        public virtual async Task<int> AttachUpdateAndSaveAsyncOnField(T entity, string fieldName)
        {
            AttachAndUpdateOnField(entity, fieldName);

            return await DataContext.SaveChangesAsync();
        }

        public virtual void AttachUpdateAsyncOnField(T entity, string fieldName)
        {
            AttachAndUpdateOnField(entity, fieldName);
        }

        public virtual void AttachAndUpdateJustField(T entity, List<string> fieldName)
        {
            DataContext.Set<T>().Attach(entity);
            foreach (var item in fieldName)
            {
                DataContext.Entry(entity).Property(item).IsModified = true;
            }

        }

        public virtual async Task<int> AttachUpdateAndSaveAsyncJustField(T entity, List<string> fieldName)
        {
            AttachAndUpdateJustField(entity, fieldName);

            return await DataContext.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            // dataContext.Set<T>().Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<int> UpdateAndSaveAsync(T entity)
        {
            Update(entity);

            return await DataContext.SaveChangesAsync();
        }

        public virtual void Remove(T entity)
        {
            DataContext.Set<T>().Remove(entity);
        }

        public virtual void RemoveNoSave(T entity)
        {
            DataContext.Set<T>().Remove(entity);
        }

        public virtual async Task<int> RemoveAndSaveAsync(T entity)
        {
            Remove(entity);

            return await DataContext.SaveChangesAsync();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await DataContext.SaveChangesAsync();
        }

        public virtual int Save()
        {
            return DataContext.SaveChanges();
        }


        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Where(predicate).SingleOrDefault();
        }

        public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Where(predicate).SingleOrDefaultAsync();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Where(predicate).FirstOrDefault();
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Where(predicate).FirstOrDefaultAsync();
        }

        public virtual List<T> ToList()
        {
            return GetAll().ToList();
        }

        public virtual async Task<List<T>> ToListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public virtual List<T> ToList(Expression<Func<T, bool>> predicate)
        {
            return Where(predicate).ToList();
        }

        public virtual async Task<List<T>> ToListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Where(predicate).ToListAsync();
        }

        public virtual int Count()
        {
            return GetAll().Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return Where(predicate).Count();
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await Where(predicate).AsNoTracking().CountAsync();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return DataContext.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DataContext.Set<T>();
        }

        public virtual void Clear()
        {
            foreach (var item in GetAll().ToList())
            {
                Remove(item);
            }
        }

        public virtual async Task ClearAsnyc()
        {
            foreach (var item in await GetAll().ToListAsync())
            {
                Remove(item);
            }
        }

        public virtual async Task ClearAndSaveAsnyc()
        {
            foreach (var item in await GetAll().ToListAsync())
            {
                Remove(item);
            }

            await SaveAsync();
        }

        public virtual async Task ClearTable()
        {
            DataContext.Set<T>().RemoveRange(DataContext.Set<T>());
            await SaveAsync();
        }

        public virtual void RemoveWhere(Expression<Func<T, bool>> predicate = null)
        {
            //Expression<Func<T, bool>> predicate
            var dbSet = DataContext.Set<T>();
            if (predicate != null)
                dbSet.RemoveRange(dbSet.Where(predicate));
            else
                dbSet.RemoveRange(dbSet);

            //DataContext.SaveChangesAsync();
        }

        public virtual async Task RemoveWhereSaveChanges(Expression<Func<T, bool>> predicate = null)
        {
            //Expression<Func<T, bool>> predicate
            var dbSet = DataContext.Set<T>();
            if (predicate != null)
                dbSet.RemoveRange(dbSet.Where(predicate));
            else
                dbSet.RemoveRange(dbSet);

            await DataContext.SaveChangesAsync();
        }

        #region IDisposable

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DataContext.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
