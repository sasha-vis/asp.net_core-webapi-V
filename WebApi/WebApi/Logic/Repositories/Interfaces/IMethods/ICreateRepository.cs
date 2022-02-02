namespace WebApi.Logic.Repositories
{
    public interface ICreateRepository<T> where T : class
    {
        public void Create(T item);
    }
}
