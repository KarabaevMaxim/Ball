using System;
using Common.Game;
using Common.Game.Props;
using Common.Game.Signals;
using Common.Game.Spawners;
using Zenject;

namespace Game.Management
{
  /// <summary>
  /// Управляющий игровым режимом скрипт. 
  /// </summary>
  public class GameManager : IGameManager
  {
    #region Зависимости

    private readonly IStairsSpawner _stairsSpawner;
    private readonly IGameplayProps _gameplayProps;
    private readonly ICharactersSpawner _charactersSpawner;
    private readonly SignalBus _signalBus;
    private readonly IObstaclesSpawner _obstaclesSpawner;
    
    #endregion

    #region Поля

    private int _currentDifficulty;

    #endregion

    #region Свойства

    public int CurrentDifficulty => _currentDifficulty;

    #endregion

    public void OnStart()
    {
      _obstaclesSpawner.Prepare();
      _stairsSpawner.Prepare();
      _currentDifficulty = _gameplayProps.StartDifficulty;
      _stairsSpawner.SpawnOnStart();
      _charactersSpawner.SpawnOnStart();
      _signalBus.Fire(new ProgressChangedSignal(0));
    }

    #region Остальные методы
    
    private GameManager(IStairsSpawner stairsSpawner,
      IGameplayProps gameplayProps,
      ICharactersSpawner charactersSpawner,
      SignalBus signalBus, 
      IObstaclesSpawner obstaclesSpawner)
    {
      _stairsSpawner = stairsSpawner;
      _gameplayProps = gameplayProps;
      _charactersSpawner = charactersSpawner;
      _signalBus = signalBus;
      _obstaclesSpawner = obstaclesSpawner;
    }

    #endregion
  }
}