using Common.Game.Spawners;
using UnityEngine;
using Zenject;

namespace Game.ObjectsModel
{
  /// <summary>
  /// Компонент объекта, перед которым появляются новые участки окружения. 
  /// </summary>
  public class LeadingObject : MonoBehaviour
  {
    private IStairsSpawner _stairsSpawner;

    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("StairsTrigger"))
      {
        _stairsSpawner.DespawnFirst();
        _stairsSpawner.SpawnNext();
      }
    }

    [Inject]
    private void Initialize(IStairsSpawner stairsSpawner)
    {
      _stairsSpawner = stairsSpawner;
    }
  }
}