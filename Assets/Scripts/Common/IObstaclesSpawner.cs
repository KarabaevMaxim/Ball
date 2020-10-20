using UnityEngine;

namespace Common
{
  public interface IObstaclesSpawner
  {
    IObstacle SpawnRandom(Vector3 position);

    void Despawn(IObstacle obj);
  }
}