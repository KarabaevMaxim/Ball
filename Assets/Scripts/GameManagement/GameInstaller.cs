using Common;
using UnityEngine;
using Zenject;

namespace GameManagement
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<IStairsSpawner>().To<StairsSpawner>().AsSingle();
      Container.BindFactory<Object, StairsObject, StairsSpawner.Factory>().FromFactory<PrefabFactory<StairsObject>>();
      Container.Bind<StairsSpawner.Pool>().AsSingle();
    }
  }
}