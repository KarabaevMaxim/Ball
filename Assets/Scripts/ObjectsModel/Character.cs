using Common;
using UnityEngine;

namespace ObjectsModel
{
  public class Character : MonoBehaviour, ICharacter
  {
    public Transform Transform => transform;

    public Vector3 Position
    {
      get => transform.position;
      set => transform.position = value;
    }

    public void OnSpawned()
    {
    }
  }
}