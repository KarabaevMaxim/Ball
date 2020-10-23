using System;
using System.Linq;
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

    #region Поля

    private User _currentUser;
    
    #endregion
    
    #region ICurrentUserInfoService

    public User CurrentUser
    {
      // если null, значит пропустили шаг регистрации в главном меню
      get =>
        _currentUser ?? (_currentUser = new User
        {
          Id = Guid.NewGuid(),
          Name = "Default user",
          BestResult = 0
        });
      set => _currentUser = value;
    }

    public async Task RegisterAsync(string name)
    {
      _currentUser = (await _usersStorage.ReadAllAsync()).FirstOrDefault(u => u.Name.Equals(name));
      
      if (_currentUser == null)
      {
        _currentUser = new User
        {
          Id = Guid.NewGuid(),
          Name = name,
          BestResult = 0
        };
        
        await _usersStorage.SaveAsync(_currentUser);
      }
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