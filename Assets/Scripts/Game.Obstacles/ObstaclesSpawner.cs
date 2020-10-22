using System;
using System.Collections.Generic;
using Common.Game;
using Common.Game.ObjectsModel;
using Common.Game.Props;
using Common.Game.Signals;
using Common.Game.Spawners;
using Infrastructure;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Game.Obstacles
{
  /// <summary>
  /// Фабрика препятствий.
  /// </summary>
  public class ObstaclesSpawner : IObstaclesSpawner, IDisposable
  {
    #region Константы

    private const int PoolCapacityForEachPrefab = 30;

    #endregion

    #region Зависимости

    private Pool _pool;
    private SignalBus _signalBus;
    private IGameplayProps _gameplayProps;
    private IDifficultyManager _difficultyManager;

    #endregion

    private bool _prepared;
    
    #region IObstaclesSpawner

    public IObstacle SpawnRandom(Vector3 position)
    {
      var obj = _pool.Spawn();
      
      if (obj == null)
        return null;

      obj.Position = position;
      obj.OnSpawned();
      return obj;
    }

    public void Despawn(IObstacle obj)
    {
      _pool.Despawn(obj);
      obj.OnDespawned();
    }

    public void Prepare()
    {
      if (!_prepared)
      {
        _pool.FillPool();
        _prepared = true;
      }
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
      _signalBus.Unsubscribe<StairsSpawnedSignal>(OnStairsSpawned);
    }

    #endregion

    #region Обработчики событий

    private void OnStairsSpawned(StairsSpawnedSignal signal)
    {
      foreach (var localCoord in signal.Stairs.StairsCoords)
      {
        var needSpawn = MathHelper.GetRandomWithProbability(_difficultyManager.CurrentDifficulty * 10);

        if (needSpawn)
        {
          var x = Random.Range(_gameplayProps.MinLine, _gameplayProps.MaxLine + 1);
          var obstacle = SpawnRandom(new Vector3(x, localCoord.Y + 1 + signal.Stairs.Position.y, localCoord.Z + signal.Stairs.Position.z));
          
          if (obstacle != null)
            signal.Stairs.AddObstacle(obstacle);
        }
      }
    }

    #endregion

    #region Остальные методы

    [Inject]
    private void Initialize(Pool pool, SignalBus signalBus, IGameplayProps gameplayProps, IDifficultyManager difficultyManager)
    {
      _pool = pool;
      _signalBus = signalBus;
      _gameplayProps = gameplayProps;
      _difficultyManager = difficultyManager;
      _signalBus.Subscribe<StairsSpawnedSignal>(OnStairsSpawned);
    }

    #endregion

    #region Вложенные типы
    
    public class Factory : PlaceholderFactory<Object, IObstacle>
    {
    }

    public class Pool
    {
      private readonly Factory _factory;
      private readonly ObstaclesProps _props;

      private readonly Dictionary<int, Queue<IObstacle>> _pool;
      private readonly IReadOnlyList<int> _ids;
      
      public IObstacle Spawn()
      {
        var obj = RandomSpawn(new List<int>(_ids.Count), 0);
        obj.SetActive(true);
        return obj;
      }

      public void Despawn(IObstacle obj)
      {
        obj.SetActive(false);
        _pool[obj.PrefabId].Enqueue(obj);
      }

      public void FillPool()
      {
        foreach (var prefab in _props.ObstaclesPrefabs)
        {
          var obj = prefab as Object;
          var id = obj.GetInstanceID();
          _pool[id] = new Queue<IObstacle>(PoolCapacityForEachPrefab);

          for (var i = 0; i < PoolCapacityForEachPrefab; i++)
          {
            var obs = _factory.Create(obj);
            obs.PrefabId = id;
            obs.SetActive(false);
;            _pool[id].Enqueue(obs);
          }
        }
      }
      
      private IObstacle RandomSpawn(ICollection<int> prevIds, int callsCount)
      {
        if (callsCount > 10)
          return null;
          
        callsCount++;
        var id = -1;

        do
        {
          var index = Random.Range(0, _ids.Count);
          id = _ids[index];

          if (prevIds.Count == _ids.Count)
            return null;

        } while (prevIds.Contains(id));
        
        prevIds.Add(id);
        
        if (_pool[id].Count == 0)
          return RandomSpawn(prevIds, callsCount);

        return _pool[id].Dequeue();
      }
      
      public Pool(Factory factory, ObstaclesProps props)
      {
        _factory = factory;
        _props = props;
        
        _pool = new Dictionary<int, Queue<IObstacle>>(_props.ObstaclesPrefabs.Count);
        _ids = _props.PrefabsIds;
      }
    }

    #endregion
  }
}