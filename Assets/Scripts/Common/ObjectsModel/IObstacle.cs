using UnityEngine;

namespace Common.ObjectsModel
{
  public interface IObstacle
  {
    int PrefabId { get; set; }
    
    Vector3 Position { get; set; }
    
    void OnSpawned();

    void OnDespawned();
  }
}