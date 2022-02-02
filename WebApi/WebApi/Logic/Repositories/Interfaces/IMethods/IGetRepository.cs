namespace WebApi.Logic.Repositories
{
    public interface IGetRepository<T> where T : class
    {
        public List<T> GetList();
        public T GetItem(int id);
    }
}
