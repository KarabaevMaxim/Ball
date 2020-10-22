using System;
using System.Threading.Tasks;
using Common.Application;
using Zenject;

namespace Application.Management
{
  public class CurrentUserInfoService : ICurrentUserInfoService
  {
    #region Зависимости

    private IStorage<User> _usersStorage;

    #endregion

    #region ICurrentUserInfoService

    public User CurrentUser { get; private set; }

    public Task RegisterAsync(string name)
    {
      CurrentUser = new User
      {
        Id = Guid.NewGuid(),
        Name = name,
        BestResult = 0
      };

      return _usersStorage.SaveAsync(CurrentUser);
    }

    public async Task SaveResultAsync(int newResult)
    {
      if (CurrentUser.BestResult < newResult)
      {
        CurrentUser.BestResult = newResult;
        await _usersStorage.SaveAsync(CurrentUser);
      }
    }

    #endregion

    #region Остальные методы

    [Inject]
    private void Initialize(IStorage<User> usersStorage)
    {
      _usersStorage = usersStorage;
    }

    #endregion
  }
}