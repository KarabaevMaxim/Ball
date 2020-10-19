namespace Common.Signals
{
  public readonly struct StairsSpawnedSignal
  {
    public YZ[] StairsCoords { get; }
    
    public StairsSpawnedSignal(YZ[] stairsCoords)
    {
      StairsCoords = stairsCoords;
    }
  }
}