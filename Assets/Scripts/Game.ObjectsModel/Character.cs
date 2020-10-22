using Common.Application;
using Common.Game.ObjectsModel;
using Common.Game.Props;
using Common.Game.Signals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.ObjectsModel
{
  public class Character : MonoBehaviour, ICharacter
  {
    #region Зависимости

    private IMovableObject _movableObject;
    private IJumpableObject _jumpableObject;
    private IGameplayProps _gameplayProps;
    private IController _controller;
    private SignalBus _signalBus;

    #endregion

    #region ICharacter
    
    public Transform Transform => transform;

    public Vector3 Position
    {
      get => transform.position;
      set => transform.position = value;
    }

    public void OnSpawned()
    {
      _controller.StartBehaviour();
    }
    
    public void OnDespawned()
    {
      _controller.StopBehaviour();
    }

    #endregion

    #region Методы Unity

    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Obstacle"))
        _signalBus.Fire<GameLoosedSignal>();
    }

    #endregion
    
    #region Остальные методы

    [Inject]
    private void Initialize(IController controller, SignalBus signalBus)
    {
      _controller = controller;
      _signalBus = signalBus;
    }

    #endregion
  }
}