using System;
using System.Collections.Generic;
using Common.Game.ObjectsModel;
using Common.Game.Props;
using UnityEngine;

namespace Game.Management.Props
{
  /// <summary>
  /// Настройки окружения в игровом режиме.
  /// </summary>
  [Serializable]
  public struct GameplayProps : IGameplayProps
  {
    #region Поля настроек

    [SerializeField]
    private int _minLine;
    
    [SerializeField]
    private int _maxLine;

    [SerializeField]
    private List<StairsObject> _stairsPrefabs;

    [SerializeField, Range(0, 10)]
    private int _startDifficulty;

    [SerializeField]
    private Vector3 _playerStartPosition;

    [SerializeField]
    private float _pseudoGravity;

    [SerializeField]
    private int _stairsToUpDifficulty;

    #endregion

    #region Свойства

    public int MinLane => _minLine;

    public int MaxLane => _maxLine;

    public IEnumerable<IStairsObject> StairsPrefabs => _stairsPrefabs;

    public int StartDifficulty => _startDifficulty;

    public Vector3 PlayerStartPosition => _playerStartPosition;

    public float PseudoGravity => _pseudoGravity;

    public int StairsToUpDifficulty => _stairsToUpDifficulty;

    #endregion

    #region Конструкторы

    public GameplayProps(int minLine, int maxLine, List<StairsObject> stairsPrefabs, int startDifficulty, Vector3 playerStartPosition, float pseudoGravity, int stairsToUpDifficulty)
    {
      _minLine = minLine;
      _maxLine = maxLine;
      _stairsPrefabs = stairsPrefabs;
      _startDifficulty = startDifficulty;
      _playerStartPosition = playerStartPosition;
      _pseudoGravity = pseudoGravity;
      _stairsToUpDifficulty = stairsToUpDifficulty;
    }

    #endregion
  }
}