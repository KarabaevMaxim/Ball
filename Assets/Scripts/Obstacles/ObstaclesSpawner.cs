using System;
using Common;
using Common.Signals;
using Zenject;

namespace Obstacles
{
  public class ObstaclesSpawner : IObstaclesSpawner, IDisposable
  {
    #region Константы

    private const int PoolCapacityForEachPrefab = 5;

    #endregion

    #region Зависимости

    private readonly SignalBus _signalBus;
    
    #endregion

    #region IObstaclesSpawner

    public void SpawnRandom()
    {
      
    }

    public void Despawn()
    {
      
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
    }

    #endregion

    #region Конструкторы

    public ObstaclesSpawner(SignalBus signalBus)
    {
      _signalBus = signalBus;
      _signalBus.Subscribe<StairsSpawnedSignal>(OnStairsSpawned);
    }

    #endregion

    #region Вложенные типы
    

    #endregion
  }
}