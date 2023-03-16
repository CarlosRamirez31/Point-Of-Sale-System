using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;

namespace Infrastructure.Persistences.Interfaces
{
    public interface IProviderRepository : IGenericRepository<Provider>
    {
        Task<BaseEntityResponse<Provider>> ListProvider(BaseFiltersRequest filter);
    }
}
