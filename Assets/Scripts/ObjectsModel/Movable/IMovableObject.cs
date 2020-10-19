using UnityEngine;

namespace ObjectsModel.Movable
{
  public interface IMovableObject
  {
    bool IsMoving { get; }
    
    void StartMove(Vector3 targetPos);

    void StopMove();
  }
}