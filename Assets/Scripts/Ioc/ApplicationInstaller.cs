using Application.Management;
using Application.Storage;
using Common.Application;
using Common.Game.ObjectsModel;
using Game.ObjectsModel;
using UnityEngine;
using Zenject;

namespace Ioc
{
  public class ApplicationInstaller : MonoInstaller
  {
    [SerializeField]
    private Character _character = default;

    public override void InstallBindings()
    {
      RegisterSignals();
      RegisterApplicationServices();
      UnityEngine.Application.targetFrameRate = 30;
    }

    private void RegisterSignals()
    {
      SignalBusInstaller.Install(Container);
    }

    private void RegisterApplicationServices()
    {
      Container.Bind<IStorage<User>>().To<JsonStorage<User>>().AsSingle();
      Container.Bind<IMediator>().To<Mediator>().AsSingle();
      Container.Bind<ICurrentUserInfoService>().To<CurrentUserInfoService>().AsSingle();
      Container.Bind<IUserDialogService>().To<UserDialogService>().AsSingle();
      Container.Bind<EmptyMonoBeh>().FromNewComponentOnNewGameObject().AsSingle();
      Container.Bind<ICharacter>().FromInstance(_character).AsSingle().IfNotBound();
    }
  }
}