using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Application
{
  public interface IStorage<TEntity> where TEntity : IEntity
  {
    void Save(TEntity entity);

    Task SaveAsync(TEntity entity);

    TEntity Read(Guid id);

    Task<TEntity> ReadAsync(Guid id);
    
    IReadOnlyList<TEntity> ReadAll();

    Task<IReadOnlyList<TEntity>> ReadAllAsync();

    void InitializeDefaultData();
  }
}