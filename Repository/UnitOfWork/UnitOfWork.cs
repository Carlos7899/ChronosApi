using ChronosApi.Data;

namespace ChronosApi.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
