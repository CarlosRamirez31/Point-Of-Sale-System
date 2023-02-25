using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;

namespace Infrastructure.Persistences.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<Category> CategoryById(int CategoryId);
        Task<bool> RegisterCategory(Category category);
        Task<bool> EditCategory (Category category);
        Task<bool> RemoveCategory (int CategoryId);
    }
}
