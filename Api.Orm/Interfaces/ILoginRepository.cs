namespace Api.Orm.Interfaces
{
    public interface ILoginRepository<T> where T : class
    {
        int Login(T obj);
    }
}
