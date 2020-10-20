using System;
using Cinemachine;
using Common;
using Common.ObjectsModel;
using Common.Signals;
using Common.Spawners;
using GameManagement;
using ObjectsModel;
using Obstacles;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Ioc
{
  public class GameInstaller : MonoInstaller
  {
    [SerializeField]
    private IGameManager _gameManager = default;

    [SerializeField]
    private Character _character = default; // todo передавать из главного меню выбранного персонажа

    public override void InstallBindings()
    {
      Container.Bind<IStairsSpawner>().To<StairsSpawner>().AsSingle();
      Container.BindFactory<Object, StairsObject, StairsSpawner.Factory>().FromFactory<PrefabFactory<StairsObject>>();
      Container.Bind<StairsSpawner.Pool>().AsSingle();
      Container.Bind<IObstaclesSpawner>().To<ObstaclesSpawner>().AsSingle().NonLazy();
      Container.BindFactory<Object, IObstacle, ObstaclesSpawner.Factory>().FromFactory<PrefabFactory<IObstacle>>();
      Container.Bind<ObstaclesSpawner.Pool>().AsSingle();
      Container.Bind<IGameManager>().FromInstance(_gameManager).AsSingle();
      Container.Bind<ICharacter>().FromInstance(_character).AsSingle();
      Container.BindFactory<Object, ICharacter, CharactersSpawner.Factory>().FromFactory<PrefabFactory<ICharacter>>();
      Container.Bind<ICharactersSpawner>().To<CharactersSpawner>().AsSingle();
      Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle();
      
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