using UnityEngine;

namespace Common
{
  public interface ICharactersSpawner
  {
    ICharacter SpawnOnStart();

    ICharacter Spawn(Vector3 position);
  }
}