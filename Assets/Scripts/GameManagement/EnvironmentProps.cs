using System;
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

    public int MinLine => _minLine;

    public int MaxLine => _maxLine;

    public EnvironmentProps(int minLine, int maxLine)
    {
      _minLine = minLine;
      _maxLine = maxLine;
    }
  }
}