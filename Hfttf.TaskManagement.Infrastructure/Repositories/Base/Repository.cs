using Hfttf.TaskManagement.Core.Entities.Base;
using Hfttf.TaskManagement.Core.Repositories.Base;
using Hfttf.TaskManagement.Infrastructure.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly TaskManagementContext _taskManagementContext;

        public Repository(TaskManagementContext taskManagementContext)
        {
            _taskManagementContext = taskManagementContext ?? throw new ArgumentNullException(nameof(taskManagementContext));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _taskManagementContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _taskManagementContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _taskManagementContext.Set<T>();

            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _taskManagementContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _taskManagementContext.Set<T>().FindAsync(id);
            if (entity != null)
                _taskManagementContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _taskManagementContext.Set<T>().Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _taskManagementContext.Set<T>().AddAsync(entity);
            await _taskManagementContext.SaveChangesAsync();
            _taskManagementContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _taskManagementContext.Entry(entity).State = EntityState.Modified;
            await _taskManagementContext.SaveChangesAsync();
            _taskManagementContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var insertedEntity = await GetByIdAsync(entity.Id);
            if (insertedEntity != null)
                _taskManagementContext.Set<T>().Remove(entity);
            int influencing = await _taskManagementContext.SaveChangesAsync();
            _taskManagementContext.Entry(entity).State = EntityState.Detached;
            if (influencing > 0)
            {
                return insertedEntity;
            }
            return insertedEntity;
        }

        public async Task<IReadOnlyList<T>> GetAllPaginationAsync(int pageNumber, int pageSize)
        {
            var pagedData = await _taskManagementContext.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
            return pagedData;
        }

        public async Task<int> CountAsync()
        {
            return await _taskManagementContext.Set<T>().CountAsync();
        }

        public async Task<int> CountFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _taskManagementContext.Set<T>().Where(predicate).CountAsync();
        }
    }
}
