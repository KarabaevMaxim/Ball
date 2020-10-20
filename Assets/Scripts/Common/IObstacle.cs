using UnityEngine;

namespace Common
{
  public interface IObstacle
  {
    int PrefabId { get; set; }
    
    Vector3 Position { get; set; }
    
    void OnSpawned();

    void OnDespawned();
  }
}