using Template.API.Data.Contexts;
using Template.API.Services.Repositories.Contracts;

namespace Template.API.Services.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Context _context;
        private IExampleRepository _example;

        public IExampleRepository Example
        {
            get
            {
                if (_example == null)
                {
                    _example = new ExampleRepository(_context);
                }

                return _example;
            }
        }

        public RepositoryWrapper(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}