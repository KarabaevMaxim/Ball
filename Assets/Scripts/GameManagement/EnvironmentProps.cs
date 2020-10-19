using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace GameManagement
{
  [Serializable]
  public struct EnvironmentProps : IEnvironmentProps
  {
    [SerializeField]
    private int _minLine;
    
    [SerializeField]
    private int _maxLine;

    [SerializeField]
    private List<StairsObject> _stairsPrefabs;

    public int MinLine => _minLine;

    public int MaxLine => _maxLine;

    public IEnumerable<IStairsObject> StairsPrefabs => _stairsPrefabs.Cast<IStairsObject>();

    public EnvironmentProps(int minLine, int maxLine, List<StairsObject> stairsPrefabs)
    {
      _minLine = minLine;
      _maxLine = maxLine;
      _stairsPrefabs = stairsPrefabs;
    }
  }
}