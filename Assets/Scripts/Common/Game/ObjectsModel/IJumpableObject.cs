using System;

namespace Common.Game.ObjectsModel
{
  public interface IJumpableObject
  {
    bool IsJumping { get; }
    
    void StartJump(float targetY, TimeSpan time);

    void StartJump(float targetY, float targetZ, TimeSpan time, Action callback);
  }
}