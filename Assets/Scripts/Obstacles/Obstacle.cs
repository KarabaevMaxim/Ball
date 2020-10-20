using Common;
using UnityEngine;

namespace Obstacles
{
  public class Obstacle : MonoBehaviour, IObstacle
  {
    public int PrefabId { get; set; }

    public void OnSpawned()
    {
      
    }

    public void OnDespawned()
    {
      
    }
  }
}