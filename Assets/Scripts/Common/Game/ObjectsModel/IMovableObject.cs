using System;
using UnityEngine;

namespace Common.Game.ObjectsModel
{
  public interface IMovableObject
  {
    bool IsMoving { get; }
    
    void StartMove(Vector3 targetPos, Action callback);

    void StopMove();
  }
}