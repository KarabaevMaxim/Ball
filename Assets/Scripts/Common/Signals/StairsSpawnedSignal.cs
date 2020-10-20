using System.Collections.Generic;

namespace Common.Signals
{
  /// <summary>
  /// Сигнал, вызываемы при появлении участка лестницы.
  /// </summary>
  public readonly struct StairsSpawnedSignal
  {
    public bool NeedSpawnObstacles { get; }
    
    public IEnumerable<YZ> StairsCoords { get; }
    
    public StairsSpawnedSignal(bool needSpawnObstacles, IEnumerable<YZ> stairsCoords)
    {
      NeedSpawnObstacles = needSpawnObstacles;
      StairsCoords = stairsCoords;
    }
  }
}