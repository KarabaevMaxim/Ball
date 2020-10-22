namespace Common.Game
{
  public interface IGameManager
  {
    int CurrentDifficulty { get; }

    void OnStart();
  }
}