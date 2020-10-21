using Common.Game.ObjectsModel;
using Common.Game.Props;
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
        SceneManager.LoadScene(0);
    }

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