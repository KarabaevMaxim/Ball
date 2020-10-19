using Common;
using UnityEngine;
using Zenject;

namespace GameManagement
{
  [CreateAssetMenu(fileName = "CommonGameSettingsInstaller", menuName = "Game settings/Common")]
  public class CommonGameSettingsInstaller : ScriptableObjectInstaller<CommonGameSettingsInstaller>
  {
    [SerializeField]
    private EnvironmentProps _environmentProps = default;

    public override void InstallBindings()
    {
      Container.Bind<IEnvironmentProps>().FromInstance(_environmentProps).IfNotBound();
    }
  }
}