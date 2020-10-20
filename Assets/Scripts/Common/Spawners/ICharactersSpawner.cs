using Common.ObjectsModel;
using UnityEngine;

namespace Common.Spawners
{
  public interface ICharactersSpawner
  {
    ICharacter SpawnOnStart();

    ICharacter Spawn(Vector3 position);

    void Despawn();
  }
}