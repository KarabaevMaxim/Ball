using Common.ObjectsModel;
using UnityEngine;

namespace Common.Spawners
{
  public interface IObstaclesSpawner
  {
    IObstacle SpawnRandom(Vector3 position);

    void Despawn(IObstacle obj);
  }
}