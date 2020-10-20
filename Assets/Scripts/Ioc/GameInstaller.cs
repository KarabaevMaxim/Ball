using System;
using Common;
using Common.Signals;
using GameManagement;
using Obstacles;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Ioc
{
  public class GameInstaller : MonoInstaller
  {
    [SerializeField]
    private IGameManager _gameManager;
    
    public override void InstallBindings()
    {
      Container.Bind<IStairsSpawner>().To<StairsSpawner>().AsSingle();
      Container.BindFactory<Object, StairsObject, StairsSpawner.Factory>().FromFactory<PrefabFactory<StairsObject>>();
      Container.Bind<StairsSpawner.Pool>().AsSingle();
      
      Container.Bind<IObstaclesSpawner>().To<ObstaclesSpawner>().AsSingle().NonLazy();
      Container.BindFactory<Object, IObstacle, ObstaclesSpawner.Factory>().FromFactory<PrefabFactory<IObstacle>>();
      Container.Bind<ObstaclesSpawner.Pool>().AsSingle();

      Container.Bind<IGameManager>().FromInstance(_gameManager).AsSingle();
      
      SignalBusInstaller.Install(Container);
      Container.DeclareSignal<StairsSpawnedSignal>();
    }

    private void OnValidate()
    {
      if (_gameManager == null)
        _gameManager = GetComponent<IGameManager>();
    }
  }
}