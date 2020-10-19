using ObjectsModel.Movable;
using UnityEngine;

namespace ObjectsModel.Controlling
{
  public class PlayerController : MonoBehaviour, IController
  {
    private IMovableObject _movableObject;
    
    public void StartBehaviour()
    {
    }

    public void StopBehaviour()
    {
    }
  }
}