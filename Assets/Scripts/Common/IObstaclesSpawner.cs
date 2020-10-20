using UnityEngine;

namespace Common
{
  public interface IObstaclesSpawner
  {
    void SpawnRandom(Vector3 position);

    void Despawn(IObstacle obj);
  }
}