using System;

namespace ObjectsModel.Jumpable
{
  public interface IJumpableObject
  {
    void StartJump(float targetY, TimeSpan time);
  }
}