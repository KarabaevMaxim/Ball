using UnityEngine;

namespace Common.Game.ObjectsModel
{
  public interface ICharacter
  {
    Transform Transform { get; }
    
    Vector3 Position { get; set; }

    void OnSpawned();

    void OnDespawned();
  }
}