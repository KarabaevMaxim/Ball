using UnityEngine;

namespace ObjectsModel.Movable
{
  public abstract class MovableObjectBase : MonoBehaviour, IMovableObject
  {
    [SerializeField]
    private float _moveSpeed = default;

    protected float MoveSpeed => _moveSpeed;

    public abstract void StartMove(Vector3 targetPos);

    public abstract void StopMove();
  }
}