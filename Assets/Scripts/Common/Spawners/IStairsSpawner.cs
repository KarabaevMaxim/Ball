namespace Common.Spawners
{
  public interface IStairsSpawner
  {
    void SpawnOnStart();

    void SpawnNext();

    void DespawnFirst();
  }
}