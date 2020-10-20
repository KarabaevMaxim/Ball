using Common;
using Common.ObjectsModel;
using UnityEngine;

namespace Obstacles
{
  public class Obstacle : MonoBehaviour, IObstacle
  {
    public int PrefabId { get; set; }

    public Vector3 Position
    {
      get => transform.position;
      set => transform.position = value;
    }

    public void OnSpawned()
    {
      
    }

    public void OnDespawned()
    {
      
    }
  }
}