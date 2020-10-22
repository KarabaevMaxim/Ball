using System;

namespace Game.ObjectsControlling.PlayerInput
{
  public interface IInput
  {
    bool Enabled { get; set; }
    
    event Action JumpForward;
    
    event Action MoveLeft;
    
    event Action MoveRight;
  }
}