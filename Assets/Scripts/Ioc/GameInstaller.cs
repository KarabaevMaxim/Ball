using Cinemachine;
using Common.Game;
using Common.Game.ObjectsModel;
using Common.Game.Signals;
using Common.Game.Spawners;
using Game.Management;
using Game.Obstacles;
using UnityEngine;
using Zenject;

namespace Ioc
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<CinemachineVirtualCamera>().FromComponentInHierarchy().AsSingle().IfNotBound();
      Container.BindFactory<Object, ICharacter, CharactersSpawner.Factory>().FromFactory<PrefabFactory<ICharacter>>().IfNotBound();
      Container.Bind<ICharactersSpawner>().To<CharactersSpawner>().AsSingle().IfNotBound();
      Container.Bind<IGameManager>().To<GameManager>().AsSingle().IfNotBound();
      Container.Bind<ProgressService>().AsSingle().NonLazy().IfNotBound();
      Container.Bind<IStairsSpawner>().To<StairsSpawner>().AsSingle().IfNotBound();
      Container.BindFactory<Object, StairsObject, StairsSpawner.Factory>().FromFactory<PrefabFactory<StairsObject>>().IfNotBound();
      Container.Bind<StairsSpawner.Pool>().AsSingle().IfNotBound();
      Container.Bind<IObstaclesSpawner>().To<ObstaclesSpawner>().AsSingle().NonLazy().IfNotBound();
      Container.BindFactory<Object, IObstacle, ObstaclesSpawner.Factory>().FromFactory<PrefabFactory<IObstacle>>().IfNotBound();
      Container.Bind<ObstaclesSpawner.Pool>().AsSingle().IfNotBound();
      Container.Bind<IDifficultyManager>().To<DifficultyManager>().AsSingle().IfNotBound();
      
      Container.DeclareSignal<StairsSpawnedSignal>();
      Container.DeclareSignal<StairPassedSignal>();
      Container.DeclareSignal<ProgressChangedSignal>();
    }

    public override void Start()
    {
      Container.Resolve<IGameManager>().OnStart();
    }
  }
}