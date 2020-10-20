namespace Common.Signals
{
  /// <summary>
  /// Сигнал, вызываемы при появлении участка лестницы.
  /// </summary>
  public readonly struct StairsSpawnedSignal
  {
    public YZ[] StairsCoords { get; }
    
    public StairsSpawnedSignal(YZ[] stairsCoords)
    {
      StairsCoords = stairsCoords;
    }
  }
}