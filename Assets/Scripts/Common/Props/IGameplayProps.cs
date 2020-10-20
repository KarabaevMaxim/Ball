using System.Collections.Generic;
using UnityEngine;

namespace Common.Props
{
  public interface IGameplayProps
  {
    int MinLine { get; }

    int MaxLine { get; }
    
    IEnumerable<IStairsObject> StairsPrefabs { get; }
    
    int StartDifficulty { get; }
    
    Vector3 PlayerStartPosition { get; }
  }
}
