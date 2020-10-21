using Common.Game.ObjectsModel;
using UnityEngine;

namespace Common.Game.Spawners
{
  public interface IObstaclesSpawner
  {
    IObstacle SpawnRandom(Vector3 position);

    void Despawn(IObstacle obj);
  }
}