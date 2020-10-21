namespace Common.Signals
{
  /// <summary>
  /// Сигнал, вызываемый при изменении счетчика прогресса.
  /// </summary>
  public readonly struct ProgressChangedSignal
  {
    public int Value { get; }
    
    public ProgressChangedSignal(int value)
    {
      Value = value;
    }
  }
}