using Common.Game;
using Common.Game.Props;
using Zenject;

namespace Game.Management
{
  public class DifficultyManager : IDifficultyManager
  {
    private int _currentDifficulty;
    
    public int CurrentDifficulty => _currentDifficulty;

    [Inject]
    private void Initialize(IGameplayProps gameplayProps)
    {
      _currentDifficulty = gameplayProps.StartDifficulty;
    }
  }
}