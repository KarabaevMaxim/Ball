using UnityEngine;

namespace Common
{
  public interface ICharacter
  {
    Transform Transform { get; }
    
    Vector3 Position { get; set; }

    void OnSpawned();
  }
}