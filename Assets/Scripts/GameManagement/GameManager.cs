using Common;
using UnityEngine;
using Zenject;

namespace GameManagement
{
  public class GameManager : MonoBehaviour
  {
    private IStairsSpawner _stairsSpawner;

    private void Start()
    {
      _stairsSpawner.SpawnOnStart();
    }

    [Inject]
    private void Initialize(IStairsSpawner stairsSpawner)
    {
      _stairsSpawner = stairsSpawner;
    }
  }
}