using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(PosContext context) : base(context) { }

        public async Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Category>();

            var categories = GetEntityQuery(c => c.AuditDeleteUser == null && c.AuditDeleteDate == null)
                .AsNoTracking();

            if(filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        categories = categories.Where(c => c.Name!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        categories = categories.Where(c => c.Description!.Contains(filters.TextFilter));
                        break;
                }
            }

            if(filters.StateFilter is not null)
            {
                categories = categories.Where(c => c.State!.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StarDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                categories = categories.Where(c => c.AuditCreateDate >= Convert.ToDateTime(filters.StarDate) &&
                c.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null) filters.Sort = "Id";

            response.TotalRecords = await categories.CountAsync();
            response.Items = await Ordering(filters, categories, filters.Download.GetValueOrDefault()).ToListAsync();
            return response;
        }
    }
}
