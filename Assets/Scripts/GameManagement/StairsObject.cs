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
    
    [SerializeField]
    private YZ[] _stairsCoords = default;

    public int Height => _height;

    public int Length => _length;

    public YZ[] StairsCoords => _stairsCoords;
  }
}