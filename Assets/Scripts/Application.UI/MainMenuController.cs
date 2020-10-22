using System;
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
    }

    private void OnDestroy()
    {
      _playBtn.onClick.RemoveAllListeners();
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