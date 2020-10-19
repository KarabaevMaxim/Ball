using System.Collections.Generic;
using Common;
using UnityEngine;
using Zenject;

namespace GameManagement
{
  public class StairsSpawner : IStairsSpawner
  {
    private const int PoolCapacityForeachPrefab = 20;
    private const int StartStairsCount = 10;
    
    private Pool _pool;
    
    private Queue<StairsObject> _activeStairs;
    private StairsObject _lastStairs;
    
    public void SpawnOnStart()
    {
      for (var i = 0; i < StartStairsCount; i++)
        SpawnNext();
    }

    public void SpawnNext()
    {
      var obj = _pool.Spawn();
 
      if (_lastStairs == null)
        obj.transform.position = new Vector3(0, 0, 0);
      else
        obj.transform.position = new Vector3(0, _lastStairs.transform.position.y + _lastStairs.Height, _lastStairs.transform.position.z + _lastStairs.Length);
      
      _lastStairs = obj;
      _activeStairs.Enqueue(obj);
    }

    public void DespawnFirst()
    {
      _pool.Despawn(_activeStairs.Dequeue());
    }

    [Inject]
    private void Initialize(IEnvironmentProps environmentProps, Pool pool)
    {
      _pool = pool;
      _activeStairs = new Queue<StairsObject>(StartStairsCount);
    }
    
    public class Factory : PlaceholderFactory<Object, StairsObject>
    {
    }
    
    public class Pool
    {
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
      
      public Pool(Factory factory, IEnvironmentProps props)
      {
        _pool = new Queue<StairsObject>(20);

        foreach (var prefab in props.StairsPrefabs)
        {
          for (var i = 0; i < PoolCapacityForeachPrefab; i++)
          {
            var obj = factory.Create(prefab as Object);
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
          }
        }
      }
    }
  }
}