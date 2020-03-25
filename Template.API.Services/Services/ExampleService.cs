using Microsoft.EntityFrameworkCore;
using Template.API.Data.Entities;
using Template.API.Services.Repositories.Contracts;
using Template.API.Services.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.API.Services.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ExampleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IRepositoryWrapper RepositoryWrapper
        {
            get
            {
                return _repositoryWrapper;
            }
        }

        public async Task<Example> Get(int id)
        {
            return await _repositoryWrapper.Example.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Example>> GetAll()
        {
            return await _repositoryWrapper.Example.FindAll().ToListAsync();
        }
    }
}