using System.Collections;
using UnityEngine;

namespace ObjectsModel.Movable
{
  public class SimpleMovableObject : MovableObjectBase
  {
    private Coroutine _moveCoroutine;
    
    public override void StartMove(Vector3 targetPos)
    {
      _moveCoroutine = StartCoroutine(Moving(targetPos));
    }

    public override void StopMove()
    {
      if (_moveCoroutine != null)
        StopCoroutine(_moveCoroutine);
    }

    private IEnumerator Moving(Vector3 targetPos)
    {
      var startPos = gameObject.transform.position;
      var step = 0.0f;
      
      while (Vector3.Distance(gameObject.transform.position, targetPos) > 0.0005f)
      {
        step += MoveSpeed * Time.deltaTime;
        Vector3.Lerp(startPos, targetPos, step);
        yield return null;
      }

      gameObject.transform.position = targetPos;
    }
  }
}