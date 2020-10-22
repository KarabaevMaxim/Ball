using System.Collections.Generic;
using Common.Game.Props;
using Common.Game.Signals;
using Common.Game.Spawners;
using UnityEngine;
using Zenject;

namespace Game.Management
{
  /// <summary>
  /// Спавнер сегментов лестницы.
  /// </summary>
  public class StairsSpawner : IStairsSpawner
  {
    #region Константы

    private const int PoolCapacityForeachPrefab = 20;
    private const int StartStairsCount = 5;

    #endregion

    #region Зависимости

    private Pool _pool;
    private SignalBus _signalBus;
    
    #endregion

    #region Поля

    private Queue<StairsObject> _activeStairs;
    private StairsObject _lastStairs;
    private bool _prepared;
    
    #endregion

    #region IStairsSpawner

    public void SpawnOnStart()
    {
      for (var i = 0; i < StartStairsCount; i++)
        SpawnNext();
    }

    public void SpawnNext()
    {
      var obj = _pool.Spawn();
 
      obj.transform.position = _lastStairs == null 
        ? new Vector3(0, 0, 0) 
        : new Vector3(0, _lastStairs.transform.position.y + _lastStairs.Height, _lastStairs.transform.position.z + _lastStairs.Length);
      
      _activeStairs.Enqueue(obj);
      _signalBus.Fire(new StairsSpawnedSignal(_lastStairs != null, obj));
      _lastStairs = obj;
    }

    public void DespawnFirst()
    {
      var stairs = _activeStairs.Dequeue();
      _pool.Despawn(stairs);
      stairs.OnDespawned();
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

    #region Остальные методы

    [Inject]
    private void Initialize(IGameplayProps gameplayProps, Pool pool, SignalBus signalBus)
    {
      _pool = pool;
      _activeStairs = new Queue<StairsObject>(StartStairsCount);
      _signalBus = signalBus;
    }


    #endregion

    #region Вложенные типы

    public class Factory : PlaceholderFactory<Object, StairsObject>
    {
    }
    
    public class Pool
    {
      private readonly Factory _factory;
      private readonly IGameplayProps _props;
      private readonly Queue<StairsObject> _pool;

      public StairsObject Spawn()
      {
        var obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
      }

      public void Despawn(StairsObject obj)
      {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
      }

      public void FillPool()
      {
        foreach (var prefab in _props.StairsPrefabs)
        {
          for (var i = 0; i < PoolCapacityForeachPrefab; i++)
          {
            var obj = _factory.Create(prefab as Object);
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
          }
        }
      }
      
      public Pool(Factory factory, IGameplayProps props)
      {
        _factory = factory;
        _props = props;
        _pool = new Queue<StairsObject>(20);
      }
    }

    #endregion
  }
}