using System;
using UnityEngine;

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
      if (Enabled)
      {
        if (Input.GetKeyDown(KeyCode.Space))
          JumpForward?.Invoke();
        
        if (Input.GetKeyDown(KeyCode.A))
          MoveLeft?.Invoke();
        
        if (Input.GetKeyDown(KeyCode.D))
          MoveRight?.Invoke();
      }
    }

    #endregion
  }
}