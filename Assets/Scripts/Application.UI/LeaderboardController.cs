using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Application;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Application.UI
{
  public class LeaderboardController : MonoBehaviour
  {
    [SerializeField]
    private Button _backBtn = default;

    [SerializeField]
    private Transform _rowsParent = default;

    [SerializeField]
    private LeaderboardRow _rowPrefab = default;

    private IStorage<User> _userStorage;

    private readonly List<LeaderboardRow> _rows = new List<LeaderboardRow>();
    
    public event Action BackBtnClicked;

    public async Task OnActivatedAsync()
    {
      gameObject.SetActive(true);
      _backBtn.onClick.AddListener(Back);
    
      var allUsers = await _userStorage.ReadAllAsync();
    
      for (var index = 0; index < allUsers.Count; index++)
      {
        var user = allUsers[index];
        var row = Instantiate(_rowPrefab, _rowsParent);
        row.Initialize(index.ToString(), user.Name, user.BestResult.ToString());
        _rows.Add(row);
      }
    }

    private void Back()
    {
      gameObject.SetActive(false);
      BackBtnClicked?.Invoke();
      _rows.ForEach(row => Destroy(row.gameObject));
      _backBtn.onClick.RemoveAllListeners();

    }

    [Inject]
    private void Initialize(IStorage<User> userStorage)
    {
      _userStorage = userStorage;
    }
  }
}