using UnityEngine;

namespace Common.Game.ObjectsModel
{
  public interface IObstacle
  {
    int PrefabId { get; set; }
    
    Vector3 Position { get; set; }
    
    void OnSpawned();

    void OnDespawned();

    void SetActive(bool value);
  }
}