using Common.Game.ObjectsModel;
using UnityEngine;

namespace Common.Game.Spawners
{
  public interface ICharactersSpawner
  {
    ICharacter SpawnOnStart();

    ICharacter Spawn(Vector3 position);

    void Despawn();
  }
}