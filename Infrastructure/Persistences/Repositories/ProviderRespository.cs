using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Utilities.Static;

namespace Infrastructure.Persistences.Repositories
{
    public class ProviderRespository : GenericRepository<Provider>, IProviderRepository
    {

        public ProviderRespository(PosContext context): base(context) { }

        public async Task<BaseEntityResponse<Provider>> ListProvider(BaseFiltersRequest filter)
        {
            var response = new BaseEntityResponse<Provider>();
            var provider = GetEntityQuery(x => x.AuditDeleteUser == null && x.AuditDeleteDate == null)
                .Include(x => x.DocumentType)
                .AsNoTracking();

            if (filter.NumFilter is not null && !string.IsNullOrEmpty(filter.TextFilter))
            {
                switch (filter.NumFilter)
                {
                    case 1:
                        provider = provider.Where(p => p.Name.Contains(filter.TextFilter));
                        break;
                    case 2:
                        provider = provider.Where(p => p.Email.Contains(filter.TextFilter));
                        break;
                    case 3: 
                        provider = provider.Where(p => p.DocumentNumber.Contains(filter.TextFilter));
                        break;
                }
            }

            if(filter.StateFilter is not null)
            {
                provider = provider.Where(p => p.State.Equals(filter.StateFilter));
            }

            if(!string.IsNullOrEmpty(filter.StarDate) && !string.IsNullOrEmpty(filter.EndDate))
            {
                provider = provider.Where(p => p.AuditCreateDate >= Convert.ToDateTime(filter.StarDate) &&
                p.AuditCreateDate <= Convert.ToDateTime(filter.EndDate).AddDays(1));
            }

            if (filter.Sort is null) filter.Sort = "Id";

            response.TotalRecords = await provider.CountAsync();
            response.Items = await Ordering(filter, provider, filter.Download.GetValueOrDefault()).ToListAsync();

            return response;
        }
    }
}
