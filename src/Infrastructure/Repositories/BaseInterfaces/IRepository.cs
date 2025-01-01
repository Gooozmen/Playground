namespace Infrastructure.Repositories.BaseInterfaces;

public interface IRepository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class { }