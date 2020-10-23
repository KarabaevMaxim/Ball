using System;
using System.Collections;
using UnityEngine;

namespace Game.ObjectsModel.Movable
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
        var x = Mathf.Lerp(startPos.x, targetPos.x, step / time);
        var z = Mathf.Lerp(startPos.z, targetPos.z, step / time);
        transform.position = new Vector3(x, transform.position.y, z);
        yield return null;
      }

      transform.position = targetPos;
      _moveCoroutine = null;
      IsMoving = false;
      callback?.Invoke();
    }
  }
}