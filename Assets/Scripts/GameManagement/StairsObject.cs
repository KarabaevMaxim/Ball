using Common;
using UnityEngine;

namespace GameManagement
{
  public class StairsObject : MonoBehaviour, IStairsObject
  {
    [SerializeField]
    private int _height = default;
    
    [SerializeField]
    private int _length = default;

    public int Height => _height;

    public int Length => _length;
  }
}