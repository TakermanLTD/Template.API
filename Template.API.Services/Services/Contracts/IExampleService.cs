using Template.API.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.API.Services.Services.Contracts
{
    public interface IExampleService : IServiceBase
    {
        Task<Example> Get(int id);
        Task<IEnumerable<Example>> GetAll();
    }
}