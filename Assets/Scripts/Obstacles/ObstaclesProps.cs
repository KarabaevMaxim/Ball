using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Obstacles
{
  [Serializable]
  public struct ObstaclesProps
  {
    [SerializeField]
    private Obstacle[] _obstaclesPrefabs;

    public IReadOnlyList<IObstacle> ObstaclesPrefabs => _obstaclesPrefabs;
    
    public IReadOnlyList<int> PrefabsIds => _obstaclesPrefabs.Select(o => o.GetInstanceID()).ToList();

    public ObstaclesProps(Obstacle[] obstaclesPrefabs)
    {
      _obstaclesPrefabs = obstaclesPrefabs;
    }
  }
}