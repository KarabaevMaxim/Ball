﻿using UnityEngine;

namespace Common
{
  public interface IMovableObject
  {
    bool IsMoving { get; }
    
    void StartMove(Vector3 targetPos);

    void StopMove();
  }
}