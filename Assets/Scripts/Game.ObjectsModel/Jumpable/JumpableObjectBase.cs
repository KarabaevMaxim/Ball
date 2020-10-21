using System;
using Common.Game.ObjectsModel;
using UnityEngine;

namespace Game.ObjectsModel.Jumpable
{
  public abstract class JumpableObjectBase : MonoBehaviour, IJumpableObject
  {
    [SerializeField]
    private float _jumpHeight = default;

    protected float JumpHeight => _jumpHeight;

    public bool IsJumping { get; protected set; }

    public abstract void StartJump(float targetY, TimeSpan time);

    public abstract void StartJump(float targetY, float targetZ, TimeSpan time, Action callback);
  }
}