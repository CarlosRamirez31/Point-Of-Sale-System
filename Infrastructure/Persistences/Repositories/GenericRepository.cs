using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Helpers;
using Infrastructure.Persistences.Interfaces;
using System.Linq.Dynamic.Core;

namespace Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable,
            bool pagination = false) where TDTO: class
        {
            IQueryable<TDTO> queryDto = (request.Order == "dec") ? queryable.OrderBy($"{request.Sort} Descensing")
                : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(request);

            return queryable;
        }
    }
}
