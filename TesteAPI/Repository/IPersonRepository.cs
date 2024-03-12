using TesteAPI.Models;

namespace TesteAPI.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person>> FindAll();
        Task<Person> FindById(long id);
        Task<bool> CreateAsync(Person person);
        Task<bool> UpdateAsync(Person person);
        Task<bool> DeleteAsync(long id);
        
    }
}
