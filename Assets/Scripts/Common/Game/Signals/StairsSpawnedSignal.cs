using Common.Game.ObjectsModel;

namespace Common.Game.Signals
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