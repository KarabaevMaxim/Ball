using Common;
using Common.ObjectsModel;
using Common.Props;
using UnityEngine;
using Zenject;

namespace ObjectsModel
{
  public class Character : MonoBehaviour, ICharacter
  {
    #region Зависимости

    private IMovableObject _movableObject;
    private IJumpableObject _jumpableObject;
    private IGameplayProps _gameplayProps;
    private IController _controller;

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

    #region Обработчики событий

    

    #endregion
    
    #region Остальные методы

    [Inject]
    private void Initialize(IController controller)
    {
      _controller = controller;
    }

    #endregion
  }
}