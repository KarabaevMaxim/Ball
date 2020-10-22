using Application.Management;
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
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;

namespace Ioc
{
  /// <summary>
  /// Общий для игрового режима и всего приложения инсталлер.
  /// </summary>
  ///  <remarks>Не стал делать отдельные контексты приложения и игры для экономии времени.</remarks>
  public class CommonHeapInstaller : MonoInstaller
  {
    [SerializeField]
    private Character _character = default;

    private CinemachineVirtualCamera _camera;
    
    public override void InstallBindings()
    {
      RegisterSignals();
      RegisterApplicationServices();
      UnityEngine.Application.targetFrameRate = 30;

      // костыль, так как нет контекста сцены
      SceneManager.sceneLoaded += (scene, mode) =>
      {
        if (scene.name == "Game")
        {
          if (_camera == null)
          {
            _camera = FindObjectOfType<CinemachineVirtualCamera>();
            Container.Bind<CinemachineVirtualCamera>().FromInstance(_camera).AsSingle().IfNotBound();
          }
            
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
          Container.Bind<ICharacter>().FromInstance(_character).AsSingle().IfNotBound();
          Container.Bind<IDifficultyManager>().To<DifficultyManager>().AsSingle().IfNotBound();

          
          Container.Resolve<IGameManager>().OnStart();
        }
      };
    }

    private void RegisterSignals()
    {
      SignalBusInstaller.Install(Container);
      Container.DeclareSignal<StairsSpawnedSignal>();
      Container.DeclareSignal<StairPassedSignal>();
      Container.DeclareSignal<ProgressChangedSignal>();
    }

    private void RegisterApplicationServices()
    {
      Container.Bind<IStorage<User>>().To<JsonStorage<User>>().AsSingle();
      Container.Bind<IMediator>().To<Mediator>().AsSingle();
      Container.Bind<ICurrentUserInfoService>().To<CurrentUserInfoService>().AsSingle();
      Container.Bind<IUserDialogService>().To<UserDialogService>().AsSingle();
      Container.Bind<EmptyMonoBeh>().FromNewComponentOnNewGameObject().AsSingle();
    }
  }
}