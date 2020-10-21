using System;
using Common.Game.ObjectsModel;
using UnityEngine;

namespace Game.ObjectsModel.Movable
{
  public abstract class MovableObjectBase : MonoBehaviour, IMovableObject
  {
    [SerializeField]
    private float _moveSpeed = default;

    protected float MoveSpeed => _moveSpeed;

    public bool IsMoving { get; protected set; }

    public abstract void StartMove(Vector3 targetPos, Action callback);

    public abstract void StopMove();
  }
}