using System;
using UnityEngine;

namespace Common
{
  /// <summary>
  /// Описание y и z координат для ступеней лестницы.
  /// </summary>
  [Serializable]
  public struct YZ
  {
    [SerializeField]
    private int _y;

    [SerializeField]
    private int _z;

    public int Y => _y;

    public int Z => _z;

    public YZ(int y, int z)
    {
      _y = y;
      _z = z;
    }
  }
}