using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using Utilities.Static;

namespace Infrastructure.Persistences.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly PosContext _context;

        public CategoryRepository(PosContext context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Category>();

            var categories = (from c in _context.Categories
                              where c.AuditDeleteUser != null && c.AuditDeleteDate != null
                              select c).AsNoTracking().AsQueryable();

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
                categories = categories.Where(c => c.AuditCreateDate >= Convert.ToDateTime(filters.StarDate) ||
                c.AuditCreateDate <= Convert.ToDateTime(filters.EndDate));
            }

            if (filters.Sort is null) filters.Sort = "CategoryId";

            response.TotalRecords = await categories.CountAsync();
            response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync();
            return response;
        }

        public async Task<IEnumerable<Category>> ListSelectCategories()
        {
            var categories = await _context.Categories
                .Where(c => c.State.Equals((int)StateType.Activo) && c.AuditDeleteDate == null).AsNoTracking().ToListAsync();

            return categories;
        }

        public async Task<Category> CategoryById(int CategoryId)
        {
            var category = await _context.Categories!
                .AsNoTracking().FirstOrDefaultAsync(c => c.CategoryId.Equals(CategoryId));

            return category!;
        }

        public async Task<bool> RegisterCategory(Category category)
        {
            category.AuditCreateUser = 1;
            category.AuditCreateDate = DateTime.Now;

            await _context.AddAsync(category);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> EditCategory(Category category)
        {
            category.AuditUpdateUser = 1;
            category.AuditUpdateDate = DateTime.Now;

            _context.Update(category);
            _context.Entry(category).Property(c => c.AuditCreateUser).IsModified = false;
            _context.Entry(category).Property(c => c.AuditCreateDate).IsModified = false;

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> RemoveCategory(int CategoryId)
        {
            var category = _context.Categories.AsNoTracking().SingleOrDefault(c => c.CategoryId.Equals(CategoryId));

            category.AuditDeleteUser = 1;
            category.AuditDeleteDate = DateTime.Now;

            _context.Update(category);

            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }
    }
}
