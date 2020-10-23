using System;
using Common.Game.ObjectsModel;
using Common.Game.Props;
using Infrastructure;
using UnityEngine;
using Zenject;

namespace Game.ObjectsControlling
{
  /// <summary>
  /// Компонент контроллера препятствиями, перемещающегося на одной ступеньке.
  /// </summary>
  public class OneStairObstacleController : MonoBehaviour, IController
  {
    #region Зависимости

    private IGameplayProps _gameplayProps;
    private IMovableObject _movableObject;

    #endregion

    #region IController

    public void StartBehaviour()
    {
      StartMoveToAnotherLane(GetXForNextMove(), MoveEnded);
    }

    public void StopBehaviour()
    {
      _movableObject.StopMove();
    }

    #endregion

    #region Остальные методы

    private int GetXForNextMove()
    {
      var curPos = transform.position;
      return Math.Abs(curPos.x - _gameplayProps.MaxLane) <= MathHelper.FloatOperationsError 
        ? _gameplayProps.MinLane 
        : _gameplayProps.MaxLane;
    }

    private void MoveEnded()
    {
      StartMoveToAnotherLane(GetXForNextMove(), MoveEnded);
    }
    
    private void StartMoveToAnotherLane(int targetX, Action callback)
    {
      var curPos = transform.position;
      _movableObject.StartMove(new Vector3(targetX, curPos.y, curPos.z), callback);
    }

    [Inject]
    private void Initialize(IGameplayProps gameplayProps, IMovableObject movableObject)
    {
      _gameplayProps = gameplayProps;
      _movableObject = movableObject;
    }

    #endregion
  }
}