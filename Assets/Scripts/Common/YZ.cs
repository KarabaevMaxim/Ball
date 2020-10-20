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
    private float _y;

    [SerializeField]
    private float _z;

    public float Y => _y;

    public float Z => _z;

    public YZ(float y, float z)
    {
      _y = y;
      _z = z;
    }
  }
}