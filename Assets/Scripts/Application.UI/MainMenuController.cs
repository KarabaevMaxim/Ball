using Common.Application;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Application.UI
{
  public class MainMenuController : MonoBehaviour
  {
    [SerializeField]
    private Button _playBtn = default;
    
    [SerializeField]
    private Button _cleanBtn = default;

    [SerializeField]
    private GameObject _mainScreen = default;
    
    [SerializeField]
    private Button _leaderboardBtn = default;

    [SerializeField]
    private LeaderboardController _leaderboardScreen = default;
    
    #region Зависимости

    private IMediator _mediator;
    private IStorage<User> _userStorage;
    private IUserDialogService _userDialogService;

    #endregion

    private void Awake()
    {
      _playBtn.onClick.AddListener(() => _mediator.StartGame());
      _cleanBtn.onClick.AddListener(() =>
      {
        _userStorage.InitializeDefaultData();
        _userDialogService.ShowDialog("Прогресс успешно удален");
      });
      _leaderboardBtn.onClick.AddListener(ToLeaderboard);
      _leaderboardScreen.BackBtnClicked += () => _mainScreen.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
      _playBtn.onClick.RemoveAllListeners();
      _cleanBtn.onClick.RemoveAllListeners();
      _leaderboardBtn.onClick.RemoveAllListeners();
    }

    private void ToLeaderboard()
    {
      _mainScreen.gameObject.SetActive(false);
      // не ждем, чтобы не блокировать UI, пока данные грузятся с хранилища
#pragma warning disable 4014
      _leaderboardScreen.OnActivatedAsync();
#pragma warning restore 4014
    }
    
    [Inject]
    private void Initialize(IMediator mediator, IStorage<User> userStorage, IUserDialogService userDialogService)
    {
      _mediator = mediator;
      _userStorage = userStorage;
      _userDialogService = userDialogService;
    }
  }
}