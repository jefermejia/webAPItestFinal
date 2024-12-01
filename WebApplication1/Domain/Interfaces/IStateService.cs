using WebApplication1.DAL.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface IStateService
    {
        /*get by id, get all, create, update, delete*/ //operaciones basicas en las API
        Task<IEnumerable<State>> GetStatesAsync();

        // get para traer estados por pais
        Task<IEnumerable<State>> GetStatesByCountryIdAsync (Guid id); // metodo nuevo estara bien ??

        Task<State> CreateStateAsync(State state);
        Task<State> GetStateByIdAsync(Guid id);
        Task<State> UpdateStateAsync(State state);
        Task<State> DeleteStateAsync(Guid id);

    }
}
