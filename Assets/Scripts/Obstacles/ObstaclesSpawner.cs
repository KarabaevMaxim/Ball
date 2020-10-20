using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Props;
using Common.Signals;
using Infrastructure;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Obstacles
{
  public class ObstaclesSpawner : IObstaclesSpawner, IDisposable
  {
    #region Константы

    private const int PoolCapacityForEachPrefab = 5;

    #endregion

    #region Зависимости

    private readonly Pool _pool;

    private readonly SignalBus _signalBus;

    private readonly IGameplayProps _gameplayProps;

    private readonly IGameManager _gameManager;

    #endregion

    #region IObstaclesSpawner

    public void SpawnRandom(Vector3 position)
    {
      var obj = _pool.Spawn();
      obj.OnSpawned();
    }

    public void Despawn(IObstacle obj)
    {
      _pool.Despawn(obj);
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
      foreach (var coord in signal.StairsCoords)
      {
        var needSpawn = MathHelper.GetRandomWithProbability(_gameManager.CurrentDifficulty * 10);

        if (needSpawn)
        {
          var x = Random.Range(_gameplayProps.MinLine, _gameplayProps.MaxLine + 1);
          SpawnRandom(new Vector3(x, coord.Y, coord.Z));
        }
      }
    }

    #endregion

    #region Конструкторы

    public ObstaclesSpawner(Pool pool, SignalBus signalBus, IGameplayProps gameplayProps, IGameManager gameManager)
    {
      _pool = pool;
      _signalBus = signalBus;
      _gameplayProps = gameplayProps;
      _gameManager = gameManager;
      _signalBus.Subscribe<StairsSpawnedSignal>(OnStairsSpawned);
    }

    #endregion

    #region Вложенные типы
    
    public class Factory : PlaceholderFactory<Object, IObstacle>
    {
    }

    public class Pool
    {
      private readonly Dictionary<int, Queue<IObstacle>> _pool;
      private readonly IReadOnlyList<int> _ids;
      
      public IObstacle Spawn()
      {
        var obj = RandomSpawn(new List<int>(_ids.Count));
        (obj as MonoBehaviour).gameObject.SetActive(true);
        return obj;
      }

      public void Despawn(IObstacle obj)
      {
        (obj as MonoBehaviour).gameObject.SetActive(false);
        _pool[obj.PrefabId].Enqueue(obj);
      } 
      
      private IObstacle RandomSpawn(ICollection<int> prevIds)
      {
        var id = -1;

        do
        {
          var index = Random.Range(0, _ids.Count);
          id = _ids[index];
        } while (prevIds.Contains(id));
        
        prevIds.Add(id);
        
        if (_pool[id].Count == 0)
          return RandomSpawn(prevIds);

        return _pool[id].Dequeue();
      }
      
      public Pool(Factory factory, ObstaclesProps props)
      {
        _pool = new Dictionary<int, Queue<IObstacle>>(props.ObstaclesPrefabs.Count);
        _ids = props.PrefabsIds;
        
        foreach (var prefab in props.ObstaclesPrefabs)
        {
          var obj = prefab as Object;
          var id = obj.GetInstanceID();
          _pool[id] = new Queue<IObstacle>(PoolCapacityForEachPrefab);

          for (var i = 0; i < PoolCapacityForEachPrefab; i++)
          {
            var obs = factory.Create(obj);
            obs.PrefabId = id;
            _pool[id].Enqueue(obs);
          }
        }
      }
    }

    #endregion
  }
}