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

    private Coroutine _behaviourCoroutine;
    private bool _started;

    #endregion

    #region IController

    public void StartBehaviour()
    {
      if (!_started)
      {
        _behaviourCoroutine = StartCoroutine(Behaviour());
        _started = true;
      }
    }

    public void StopBehaviour()
    {
      if (_behaviourCoroutine != null)
      {
        StopCoroutine(_behaviourCoroutine);
        _behaviourCoroutine = null;
      }

      _started = false;
    }

    #endregion

    #region Остальные методы

    private IEnumerator Behaviour()
    {
      while (true)
      {
        yield return null;
      }
    }

    [Inject]
    private void Initialize(IMovableObject movableObject)
    {
      _movableObject = movableObject;
    }

    #endregion
  }
}