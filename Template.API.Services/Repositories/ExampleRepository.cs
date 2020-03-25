using Template.API.Data.Contexts;
using Template.API.Data.Entities;
using Template.API.Services.Repositories.Contracts;

namespace Template.API.Services.Repositories
{
    public class ExampleRepository : RepositoryBase<Example>, IExampleRepository
    {
        public ExampleRepository(Context context)
            : base(context)
        {
        }
    }
}