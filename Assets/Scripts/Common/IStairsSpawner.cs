namespace Common
{
  public interface IStairsSpawner
  {
    void SpawnOnStart();

    void SpawnNext();

    void DespawnFirst();
  }
}