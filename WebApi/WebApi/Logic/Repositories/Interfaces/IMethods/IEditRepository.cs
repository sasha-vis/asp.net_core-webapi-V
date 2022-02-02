namespace WebApi.Logic.Repositories
{
    public interface IEditRepository<T> where T : class
    {
        public void Edit(T item);
    }
}
