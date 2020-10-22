using System;
using System.Threading.Tasks;
using Common.Application;
using Zenject;

namespace Application.Management
{
  public class CurrentUserInfoService : ICurrentUserInfoService
  {
    private IStorage<User> _usersStorage;
    
    private User _currentUser;
    
    public Task RegisterAsync(string name)
    {
      _currentUser = new User
      {
        Id = Guid.NewGuid(),
        Name = name,
        TotalResult = 0
      };

      return _usersStorage.SaveAsync(_currentUser);
    }

    [Inject]
    private void Initialize(IStorage<User> usersStorage)
    {
      _usersStorage = usersStorage;
    }
  }
}