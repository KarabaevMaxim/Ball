using Common.ObjectsModel;
using UnityEngine;
using Zenject;

namespace Obstacles
{
  public class Obstacle : MonoBehaviour, IObstacle
  {
    #region Зависимости

    private IController _controller;

    #endregion
    
    #region IObstacle

    public int PrefabId { get; set; }

    public Vector3 Position
    {
      get => transform.position;
      set => transform.position = value;
    }

    public void OnSpawned()
    {
      
    }

    public void OnDespawned()
    {
      
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