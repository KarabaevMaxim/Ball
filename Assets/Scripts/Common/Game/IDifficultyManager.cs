namespace Common.Game
{
  /// <summary>
  /// Сервис, управляющий сложностью игры.
  /// </summary>
  public interface IDifficultyManager
  {
    int CurrentDifficulty { get; }
  }
}