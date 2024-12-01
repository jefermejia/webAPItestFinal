using WebApplication1.DAL.Entities;

namespace WebApplication1.Domain.Interfaces
{
    public interface ICountryService
    {
        /*get by id, get all, create, update, delete*/ //operaciones basicas en las API
        Task<IEnumerable<Country>> GetCountriesAsync(); // on esto se busca listar todos los paises

        Task<Country> CreateCountryAsync (Country country);
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> UpdateCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);

    }
}
