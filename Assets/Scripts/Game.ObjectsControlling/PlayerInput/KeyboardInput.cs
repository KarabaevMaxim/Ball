using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.ObjectsControlling.PlayerInput
{
  /// <summary>
  /// Компонент ввода с клавиатуры.
  /// </summary>
  public class KeyboardInput : MonoBehaviour, IInput
  {
    #region IInput

    public bool Enabled { get; set; }

    public event Action JumpForward;

    public event Action MoveLeft;
    
    public event Action MoveRight;

    #endregion

    #region Методы Unity

    private void Update()
    {
      var keyboard = Keyboard.current;
      
      if (keyboard == null)
        return;
      
      if (Enabled)
      {
        if (keyboard.spaceKey.wasPressedThisFrame)
          JumpForward?.Invoke();
        
        if (keyboard.aKey.wasPressedThisFrame)
          MoveLeft?.Invoke();
        
        if (keyboard.dKey.wasPressedThisFrame)
          MoveRight?.Invoke();
      }
    }

    #endregion
  }
}