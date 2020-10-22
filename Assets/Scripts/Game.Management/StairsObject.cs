using System.Collections.Generic;
using Common.Game;
using Common.Game.ObjectsModel;
using Common.Game.Spawners;
using UnityEngine;
using Zenject;

namespace Game.Management
{
  /// <summary>
  /// Компонент сегмента лестницы.
  /// </summary>
  public class StairsObject : MonoBehaviour, IStairsObject
  {
    #region Поля настройки

    [SerializeField]
    private int _height = default;
    
    [SerializeField]
    private int _length = default;
    
    [SerializeField]
    private YZ[] _stairsCoords = default;

    #endregion

    #region Зависимости

    private IObstaclesSpawner _obstaclesSpawner;

    #endregion
    
    #region Поля

    private List<IObstacle> _obstacles;

    #endregion

    #region IStairsObject

    public int Height => _height;

    public int Length => _length;

    public YZ[] StairsCoords => _stairsCoords;

    public Vector3 Position
    {
      get => transform.position;
      set => transform.position = value;
    }
    
    public void OnDespawned()
    {
      _obstacles.ForEach(_obstaclesSpawner.Despawn);
      _obstacles.Clear();
    }

    public void AddObstacle(IObstacle obstacle)
    {
      _obstacles.Add(obstacle);
    }

    #endregion

    #region Остальные методы

    [Inject]
    private void Initialize(IObstaclesSpawner obstaclesSpawner)
    {
      _obstaclesSpawner = obstaclesSpawner;
      _obstacles = new List<IObstacle>(5);
    }

    #endregion
  }
}