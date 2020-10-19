using System;
using UnityEngine;

namespace Common
{
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