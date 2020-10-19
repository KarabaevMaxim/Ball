using System;
using UnityEngine;

namespace ObjectsModel.Jumpable
{
  public abstract class JumpableObjectBase : MonoBehaviour, IJumpableObject
  {
    [SerializeField]
    private float _jumpHeight;

    protected float JumpHeight => _jumpHeight;

    public abstract void StartJump(float targetY, TimeSpan time);
  }
}