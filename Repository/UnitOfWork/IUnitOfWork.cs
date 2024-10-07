namespace ChronosApi.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
