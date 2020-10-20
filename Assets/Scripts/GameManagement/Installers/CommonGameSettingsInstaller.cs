using Common.Props;
using GameManagement.Props;
using UnityEngine;
using Zenject;

namespace GameManagement.Installers
{
  /// <summary>
  /// Инсталлер настроек игрового режима.
  /// </summary>
  [CreateAssetMenu(fileName = "CommonGameSettingsInstaller", menuName = "Game settings/Common")]
  public class CommonGameSettingsInstaller : ScriptableObjectInstaller<CommonGameSettingsInstaller>
  {
    [SerializeField]
    private GameplayProps _gameplayProps = default;

    public override void InstallBindings()
    {
      Container.Bind<IGameplayProps>().FromInstance(_gameplayProps).IfNotBound();
    }
  }
}