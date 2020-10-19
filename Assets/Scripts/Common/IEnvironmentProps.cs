using System.Collections.Generic;

namespace Common
{
  public interface IEnvironmentProps
  {
    int MinLine { get; }

    int MaxLine { get; }
    
    IEnumerable<IStairsObject> StairsPrefabs { get; }
  }
}
