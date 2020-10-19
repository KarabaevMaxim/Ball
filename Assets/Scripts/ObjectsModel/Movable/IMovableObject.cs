using UnityEngine;

namespace ObjectsModel.Movable
{
  public interface IMovableObject
  {
    void StartMove(Vector3 targetPos);

    void StopMove();
  }
}