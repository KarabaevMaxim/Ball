using Application.Storage;
using Cinemachine;
using Common.Application;
using Common.Game;
using Common.Game.ObjectsModel;
using Common.Game.Signals;
using Common.Game.Spawners;
using Game.Management;
using Game.ObjectsModel;
using Game.Obstacles;
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
      RegisterGameServicesAndSignals();
      // чтобы не тратить время на разделение контекстов, зарегистрирую все в одной куче
      RegisterApplicationServicesAndSignals();
      UnityEngine.Application.targetFrameRate = 30;
    }

    private void RegisterGameServicesAndSignals()
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
      Container.Bind<ProgressService>().AsSingle().NonLazy();
      
      SignalBusInstaller.Install(Container);
      Container.DeclareSignal<StairsSpawnedSignal>();
      Container.DeclareSignal<StairPassedSignal>();
      Container.DeclareSignal<ProgressChangedSignal>();
    }

    private void RegisterApplicationServicesAndSignals()
    {
      Container.Bind<IStorage<User>>().To<JsonStorage<User>>().AsSingle();
    }
    
    private void OnValidate()
    {
      if (_gameManager == null)
        _gameManager = GetComponent<IGameManager>();
    }
  }
}