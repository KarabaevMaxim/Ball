using System;

namespace ObjectsModel.Jumpable
{
  public interface IJumpableObject
  {
    bool IsJumping { get; }
    
    void StartJump(float targetY, TimeSpan time);

    void StartJump(float targetY, float targetZ, TimeSpan time);
  }
}