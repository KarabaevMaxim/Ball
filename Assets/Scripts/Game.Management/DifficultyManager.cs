using System;
using Common.Game;
using Common.Game.Props;
using Common.Game.Signals;
using UnityEngine;
using Zenject;

namespace Game.Management
{
  public class DifficultyManager : IDifficultyManager, IDisposable
  {
    private SignalBus _signalBus;
    private IGameplayProps _gameplayProps;

    private int _currentDifficulty;
    private int _stairsCounter;
    
    public int CurrentDifficulty => _currentDifficulty;

    public void Dispose()
    {
      _signalBus.Unsubscribe<StairPassedSignal>(OnStairPassed);
    }

    private void OnStairPassed()
    {
      _stairsCounter++;

      if (_stairsCounter >= _gameplayProps.StartDifficulty)
      {
        if (_currentDifficulty < 10) // 10 - максимальная сложность
        {
          _currentDifficulty++;
          Debug.Log($"Сложность увеличена. Сложность: {_currentDifficulty}");
          _stairsCounter = 0;
        }
      }
    }
    
    [Inject]
    private void Initialize(IGameplayProps gameplayProps, SignalBus signalBus)
    {
      _currentDifficulty = gameplayProps.StartDifficulty;
      _gameplayProps = gameplayProps;
      _signalBus = signalBus;
      _signalBus.Subscribe<StairPassedSignal>(OnStairPassed);
    }
  }
}