namespace Common
{
  public interface IObstacle
  {
    int PrefabId { get; set; }
    
    void OnSpawned();

    void OnDespawned();
  }
}