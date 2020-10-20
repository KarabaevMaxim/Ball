using System.Collections.Generic;

namespace Common.Props
{
  public interface IGameplayProps
  {
    int MinLine { get; }

    int MaxLine { get; }
    
    IEnumerable<IStairsObject> StairsPrefabs { get; }
    
    int StartDifficulty { get; }
  }
}
