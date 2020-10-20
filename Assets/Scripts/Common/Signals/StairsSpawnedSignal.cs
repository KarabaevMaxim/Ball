using System.Collections.Generic;

namespace Common.Signals
{
  /// <summary>
  /// Сигнал, вызываемы при появлении участка лестницы.
  /// </summary>
  public readonly struct StairsSpawnedSignal
  {
    public IEnumerable<YZ> StairsCoords { get; }
    
    public StairsSpawnedSignal(IEnumerable<YZ> stairsCoords)
    {
      StairsCoords = stairsCoords;
    }
  }
}