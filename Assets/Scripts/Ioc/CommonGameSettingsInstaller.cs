using Common.Game.Props;
using Game.GameManagement.Props;
using Game.Obstacles;
using UnityEngine;
using Zenject;

namespace Ioc
{
  /// <summary>
  /// Инсталлер настроек игрового режима.
  /// </summary>
  [CreateAssetMenu(fileName = "CommonGameSettingsInstaller", menuName = "Game settings/Common")]
  public class CommonGameSettingsInstaller : ScriptableObjectInstaller<CommonGameSettingsInstaller>
  {
    [SerializeField]
    private GameplayProps _gameplayProps = default;

    [SerializeField]
    private ObstaclesProps _obstaclesProps = default;
    
    public override void InstallBindings()
    {
      Container.Bind<IGameplayProps>().FromInstance(_gameplayProps).IfNotBound();
      Container.Bind<ObstaclesProps>().FromInstance(_obstaclesProps).IfNotBound();
    }
  }
}