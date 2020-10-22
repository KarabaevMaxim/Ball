using System;
using Common.Game;
using Common.Game.Signals;
using UnityEngine;
using Zenject;

namespace Game.Management
{
  public class ProgressService : IDisposable
  {
    #region Зависимости

    private readonly SignalBus _signalBus;
    private readonly IDifficultyManager _difficultyManager;

    #endregion

    #region Свойства

    public int TotalStairs { get; private set; }

    #endregion

    #region IDisposable

    public void Dispose()
    {
      _signalBus.Unsubscribe<StairPassedSignal>(OnStairPassed);
    }

    #endregion

    private void OnStairPassed()
    {
      TotalStairs += Mathf.RoundToInt(_difficultyManager.CurrentDifficulty / 2.0f);
      _signalBus.Fire(new ProgressChangedSignal(TotalStairs));
    }
    
    public ProgressService(SignalBus signalBus, IDifficultyManager difficultyManager)
    {
      _signalBus = signalBus;
      _difficultyManager = difficultyManager;
      _signalBus.Subscribe<StairPassedSignal>(OnStairPassed);
    }
  }
}