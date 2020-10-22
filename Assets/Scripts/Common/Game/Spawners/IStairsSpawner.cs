namespace Common.Game.Spawners
{
  public interface IStairsSpawner
  {
    void SpawnOnStart();

    void SpawnNext();

    void DespawnFirst();

    void Prepare();
  }
}