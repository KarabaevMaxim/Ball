using System;
using Common.Application;
using Common.Game;
using Common.Game.Signals;
using Common.Game.Spawners;
using Zenject;

namespace Game.Management
{
  /// <summary>
  /// Сервис, управляющий игровым режимом. 
  /// </summary>
  public class GameManager : IGameManager, IDisposable
  {
    #region Зависимости

    private readonly IStairsSpawner _stairsSpawner;
    private readonly ICharactersSpawner _charactersSpawner;
    private readonly SignalBus _signalBus;
    private readonly IObstaclesSpawner _obstaclesSpawner;
    private readonly IMediator _mediator;
    private readonly ICurrentUserInfoService _currentUserInfoService;

    private readonly ProgressService _progressService;

    #endregion

    #region IGameManager

    public void OnStart()
    {
      _obstaclesSpawner.Prepare();
      _stairsSpawner.Prepare();
      _stairsSpawner.SpawnOnStart();
      _charactersSpawner.SpawnOnStart();
      _signalBus.Fire(new ProgressChangedSignal(0));
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
      _signalBus.Unsubscribe<GameLoosedSignal>(OnGameLoosed);
    }

    #endregion

    #region Остальные методы

    private void OnGameLoosed()
    {
      _currentUserInfoService.SaveResultAsync(_progressService.TotalStairs);
      _mediator.RestartGame();
    }

    #endregion
    
    #region Конструкторы
    
    public GameManager(IStairsSpawner stairsSpawner,
      ICharactersSpawner charactersSpawner,
      SignalBus signalBus, 
      IObstaclesSpawner obstaclesSpawner,
      IMediator mediator,
      ICurrentUserInfoService currentUserInfoService,
      ProgressService progressService)
    {
      _stairsSpawner = stairsSpawner;
      _charactersSpawner = charactersSpawner;
      _signalBus = signalBus;
      _obstaclesSpawner = obstaclesSpawner;
      _mediator = mediator;
      _currentUserInfoService = currentUserInfoService;
      _progressService = progressService;
      _signalBus.Subscribe<GameLoosedSignal>(OnGameLoosed);
    }

    #endregion
  }
}