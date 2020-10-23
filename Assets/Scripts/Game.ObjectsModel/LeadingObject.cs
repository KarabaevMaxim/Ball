using Common.Game.Signals;
using UnityEngine;
using Zenject;

namespace Game.ObjectsModel
{
  /// <summary>
  /// Компонент объекта, перед которым появляются новые участки окружения. 
  /// </summary>
  public class LeadingObject : MonoBehaviour
  {
    private SignalBus _signalBus;

    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("StairsTrigger"))
      {
        _signalBus.Fire<LeadingObjectPassedStairsBlock>();
      }
    }

    [Inject]
    private void Initialize(SignalBus signalBus)
    {
      _signalBus = signalBus;
    }
  }
}