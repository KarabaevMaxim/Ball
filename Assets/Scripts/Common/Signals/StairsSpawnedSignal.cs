using Common.ObjectsModel;

namespace Common.Signals
{
  /// <summary>
  /// Сигнал, вызываемы при появлении участка лестницы.
  /// </summary>
  public readonly struct StairsSpawnedSignal
  {
    public bool NeedSpawnObstacles { get; }
    
    public IStairsObject Stairs { get; }
    
    public StairsSpawnedSignal(bool needSpawnObstacles, IStairsObject stairs)
    {
      NeedSpawnObstacles = needSpawnObstacles;
      Stairs = stairs;
    }
  }
}