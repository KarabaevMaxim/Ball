using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Props;
using UnityEngine;

namespace GameManagement.Props
{
  /// <summary>
  /// Настройки окружения в игровом режиме.
  /// </summary>
  [Serializable]
  public struct GameplayProps : IGameplayProps
  {
    [SerializeField]
    private int _minLine;
    
    [SerializeField]
    private int _maxLine;

    [SerializeField]
    private List<StairsObject> _stairsPrefabs;

    [SerializeField, Range(0, 10)]
    private int _startDifficulty;

    public int MinLine => _minLine;

    public int MaxLine => _maxLine;

    public IEnumerable<IStairsObject> StairsPrefabs => _stairsPrefabs;

    public int StartDifficulty => _startDifficulty;

    public GameplayProps(int minLine, int maxLine, List<StairsObject> stairsPrefabs, int startDifficulty)
    {
      _minLine = minLine;
      _maxLine = maxLine;
      _stairsPrefabs = stairsPrefabs;
      _startDifficulty = startDifficulty;
    }
  }
}