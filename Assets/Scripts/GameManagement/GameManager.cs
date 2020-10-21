using Common;
using Common.Props;
using Common.Signals;
using Common.Spawners;
using UnityEngine;
using Zenject;

namespace GameManagement
{
  /// <summary>
  /// Управляющий игровым режимом скрипт. 
  /// </summary>
  public class GameManager : MonoBehaviour, IGameManager
  {
    #region Зависимости

    private IStairsSpawner _stairsSpawner;
    private IGameplayProps _gameplayProps;
    private ICharactersSpawner _charactersSpawner;
    private SignalBus _signalBus;
    
    #endregion

    #region Поля

    private int _currentDifficulty;
    
    #endregion

    #region Свойства

    public int CurrentDifficulty => _currentDifficulty;

    #endregion

    #region Методы Unity

    private void Start()
    {
      _currentDifficulty = _gameplayProps.StartDifficulty;
      _stairsSpawner.SpawnOnStart();
      _charactersSpawner.SpawnOnStart();
      _signalBus.Fire(new ProgressChangedSignal(0));
    }

    #endregion

    #region Остальные методы

    [Inject]
    private void Initialize(IStairsSpawner stairsSpawner, IGameplayProps gameplayProps, ICharactersSpawner charactersSpawner, SignalBus signalBus)
    {
      _stairsSpawner = stairsSpawner;
      _gameplayProps = gameplayProps;
      _charactersSpawner = charactersSpawner;
      _signalBus = signalBus;
    }

    #endregion
  }
}