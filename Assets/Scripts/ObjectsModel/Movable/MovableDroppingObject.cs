using System.Collections;
using Common.Props;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace ObjectsModel.Movable
{
  /// <summary>
  /// Компонент объекта, который может перемещаться и на который действует гравитация.
  /// </summary>
  public class MovableDroppingObject : MovableObjectBase
  {
    #region Зависимости

    private IGameplayProps _gameplayProps;

    #endregion

    #region Поля

    private readonly RaycastHit[] _buffer = new RaycastHit[1];
    private Coroutine _moveCoroutine;
    private int _layerMask;

    #endregion

    #region MovableObjectBase

    /// <summary>
    /// Запускает линейное перемещение.
    /// </summary>
    /// <remarks>Перемещение по координате Y будет происходить за счет псевдофизики.</remarks>
    /// <param name="targetPos">Конечная позиция. Компонента Y игнорируется.</param>
    public override void StartMove(Vector3 targetPos)
    {
      _moveCoroutine = StartCoroutine(Move(targetPos));
    }

    public override void StopMove()
    {
      if (_moveCoroutine != null)
      {
        StopCoroutine(_moveCoroutine);
        _moveCoroutine = null;
      }
    }

    #endregion
    
    #region Остальные методы

    private IEnumerator Move(Vector3 targetPos)
    {
      while (MathHelper.GetDistanceByHorizontalPlane(transform.position, targetPos) >= MathHelper.FloatOperationsError)
      {
        var currentPosition = transform.position;
        var delta = MoveSpeed * Time.deltaTime;

        var newPosition = Vector3.MoveTowards(
          currentPosition,
          new Vector3(targetPos.x, currentPosition.y, targetPos.z),
          delta);

        var rcOrigin = new Vector3(currentPosition.x + .5f, currentPosition.y, currentPosition.z + .5f);
        if (Physics.RaycastNonAlloc(rcOrigin, Vector3.down, _buffer, .2f, _layerMask) == 0)
        {
          var dropDelta = _gameplayProps.PseudoGravity * Time.deltaTime;
          newPosition.y = currentPosition.y - dropDelta;
        }
        else
        {
          newPosition.y = Mathf.Round(currentPosition.y);
        }
        
        // if (Physics.Raycast(new Vector3(currentPosition.x + .5f, currentPosition.y, currentPosition.z + .5f), Vector3.down, .3f))
        // {
        //   newPosition.y = Mathf.Round(currentPosition.y);
        // }
        // else
        // {
        //   var dropDelta = _gameplayProps.PseudoGravity * Time.deltaTime;
        //   newPosition.y = currentPosition.y - dropDelta;
        // }

        transform.position = newPosition;
        
        yield return null;
      }
      
      transform.position = new Vector3(targetPos.x, transform.position.y, targetPos.z);
    }

    [Inject]
    private void Initialize(IGameplayProps gameplayProps)
    {
      _gameplayProps = gameplayProps;
      _layerMask = LayerMask.GetMask("Stair");
    }

    #endregion
  }
}