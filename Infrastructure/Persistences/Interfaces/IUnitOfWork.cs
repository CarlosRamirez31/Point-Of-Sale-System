namespace Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        IProviderRepository Provider { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
