namespace Template.API.Services.Repositories.Contracts
{
    public interface IRepositoryWrapper
    {
        IExampleRepository Example { get; }

        void Save();
    }
}