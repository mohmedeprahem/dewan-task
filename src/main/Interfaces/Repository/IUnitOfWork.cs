namespace main.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        IReceiptRepository ReceiptRepository { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
