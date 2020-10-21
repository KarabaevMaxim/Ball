using System.Collections;
using Common.ObjectsModel;
using UnityEngine;
using Zenject;

namespace ObjectsControlling
{
  /// <summary>
  /// Компонент управления простыми препятствиями. Препятствие бежит вниз и падает со ступенек.
  /// </summary>
  public class SimpleObstacleController : MonoBehaviour, IController
  {
    #region Зависимости

    private IMovableObject _movableObject;

    #endregion

    #region Поля
    
    private bool _started;

    #endregion

    #region IController

    public void StartBehaviour()
    {
      if (!_started)
      {
        _movableObject.StartMove(new Vector3(transform.position.x, 0, 0));
        _started = true;
      }
    }

    public void StopBehaviour()
    {
      if (_started)
      {
        _movableObject.StopMove();
        _started = false;
      }
    }

    #endregion

    #region Остальные методы

    [Inject]
    private void Initialize(IMovableObject movableObject)
    {
      _movableObject = movableObject;
    }

    #endregion
  }
}