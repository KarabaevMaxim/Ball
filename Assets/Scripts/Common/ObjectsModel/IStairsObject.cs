using UnityEngine;

namespace Common.ObjectsModel
{
  public interface IStairsObject
  {
    int Height { get; }

    int Length { get; }
    
    YZ[] StairsCoords { get; }
    
    Vector3 Position { get; set; }

    void OnDespawned();

    void AddObstacle(IObstacle obstacle);
  }
}