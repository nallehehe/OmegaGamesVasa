namespace Common.Interface;

public interface IEventService<T> where T : class
{
    Task<IEnumerable<T>> GetAllEvents();

    Task AddEventAsync(T e);
}