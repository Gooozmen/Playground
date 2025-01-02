namespace Infrastructure.Repositories.Base;

public interface IBaseRepository<T> : ICommandRepository<T>, IQueryRepository<T> where T : class { }

