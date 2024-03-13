namespace domain.Interfaces.ICRUDservices.common
{
    public interface IBaseCRUDServices<T>
    {
        Task<List<T>> GetEntities();
        Task<T> GetEntity(int id);
        Task<T> UpdateEntity(int id, T dto);
        Task<T> AddEntity(T dto);
        Task<T> DeleteEntity(int id);

    }
}
