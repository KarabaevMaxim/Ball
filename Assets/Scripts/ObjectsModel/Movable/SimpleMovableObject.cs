using System;
using System.Collections;
using UnityEngine;

namespace ObjectsModel.Movable
{
  public class SimpleMovableObject : MovableObjectBase
  {
    private Coroutine _moveCoroutine;

    public override void StartMove(Vector3 targetPos, Action callback)
    {
      if (!IsMoving)
      {
        _moveCoroutine = StartCoroutine(Moving(targetPos, callback));
        IsMoving = true;
      }
    }

    public override void StopMove()
    {
      if (_moveCoroutine != null)
        StopCoroutine(_moveCoroutine);

      IsMoving = false;
    }

    private IEnumerator Moving(Vector3 targetPos, Action callback)
    {
      var startPos = transform.position;
      var range = Vector3.Distance(startPos, targetPos);
      var time = range / MoveSpeed;
      var step = 0.0f;

      while (step <= time)
      {
        step += Time.deltaTime;
        transform.position = Vector3.Lerp(startPos, targetPos, step / time);
        yield return null;
      }

      transform.position = targetPos;
      _moveCoroutine = null;
      IsMoving = false;
      callback?.Invoke();
    }
  }
}