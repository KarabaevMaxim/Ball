using System;
using Common.Signals;
using Zenject;

namespace GameManagement
{
  public class ProgressService : IDisposable
  {
    private readonly SignalBus _signalBus;

    private int _totalStairs;
    
    private void OnStairPassed()
    {
      _totalStairs++;
      _signalBus.Fire(new ProgressChangedSignal(_totalStairs));
    }
    
    public void Dispose()
    {
      _signalBus.Unsubscribe<StairPassedSignal>(OnStairPassed);
    }
    
    public ProgressService(SignalBus signalBus)
    {
      _signalBus = signalBus;
      _signalBus.Subscribe<StairPassedSignal>(OnStairPassed);
    }
  }
}