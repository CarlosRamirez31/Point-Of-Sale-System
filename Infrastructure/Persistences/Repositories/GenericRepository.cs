using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Helpers;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Utilities.Static;

namespace Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        private readonly PosContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(PosContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsyn()
        {
            var response = await _entity
                .Where(e => e.State.Equals((int)StateType.Activo) && e.AuditDeleteUser == null && e.AuditDeleteDate == null)
                .AsNoTracking().ToListAsync();

            return response;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _entity!.AsNoTracking().Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();

            return response!;
        }
        
        public async Task<bool> RegisterAsync(T entity)
        {
            entity.AuditCreateUser = 1;
            
            await _context.AddAsync(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> EditAsync(T entity)
        {
            entity.AuditUpdateUser = 1;

            _context.Update(entity);
            _context.Entry(entity).Property(c => c.AuditCreateUser).IsModified = false;
            _context.Entry(entity).Property(c => c.AuditCreateDate).IsModified = false;

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            entity!.AuditDeleteUser = 1;
            entity.AuditDeleteDate = DateTime.Now;

            _context.Update(entity);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter != null) query = query.Where(filter);

            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable,
            bool pagination = false) where TDTO: class
        {
            IQueryable<TDTO> queryDto = (request.Order == "desc") ? queryable.OrderBy($"{request.Sort} descending")
                : queryable.OrderBy($"{request.Sort} ascending");

            if (!pagination) queryDto = queryDto.Paginate(request);

            return queryDto;
        }
    }
}
