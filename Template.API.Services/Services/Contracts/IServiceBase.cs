using Template.API.Services.Repositories.Contracts;

namespace Template.API.Services.Services.Contracts
{
    public interface IServiceBase
    {
        IRepositoryWrapper RepositoryWrapper { get; }
    }
}