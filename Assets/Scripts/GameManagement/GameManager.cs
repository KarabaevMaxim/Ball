using Common;
using Common.Props;
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
    }

    #endregion

    #region Остальные методы

    [Inject]
    private void Initialize(IStairsSpawner stairsSpawner, IGameplayProps gameplayProps)
    {
      _stairsSpawner = stairsSpawner;
      _gameplayProps = gameplayProps;
    }

    #endregion
  }
}