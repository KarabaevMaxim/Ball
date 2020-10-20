using Common;
using Common.ObjectsModel;
using UnityEngine;

namespace ObjectsModel.Movable
{
  public abstract class MovableObjectBase : MonoBehaviour, IMovableObject
  {
    [SerializeField]
    private float _moveSpeed = default;

    protected float MoveSpeed => _moveSpeed;

    public bool IsMoving { get; protected set; }

    public abstract void StartMove(Vector3 targetPos);

    public abstract void StopMove();
  }
}