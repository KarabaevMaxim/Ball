using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace Game.ObjectsControlling.PlayerInput
{
  /// <summary>
  /// Компонент ввода с сенсорного экрана.
  /// </summary>
  public class TouchScreenInput : MonoBehaviour, IInput
  {
    #region Константы

    private const int SwipeSensitivity = 100;

    #endregion
    
    #region Поля

    private Vector2 _startPos;
    private bool _enabled;
    private bool _swiped;

    #endregion
    
    #region IInput

    public bool Enabled
    {
      get => _enabled;
      set
      {
        if (_enabled == value)
          return;
        
        _enabled = value;

        if (_enabled)
        {
          EnhancedTouchSupport.Enable();
          Touch.onFingerDown += OnTouchDown;
          Touch.onFingerUp += OnTouchUp;
          Touch.onFingerMove += OnTouchMove;
        }
        else
        {
          EnhancedTouchSupport.Disable();
          Touch.onFingerDown -= OnTouchDown;
          Touch.onFingerUp -= OnTouchUp;
          Touch.onFingerMove -= OnTouchMove;
        }
      }
    }

    public event Action JumpForward;

    public event Action MoveLeft;

    public event Action MoveRight;

    #endregion

    #region Остальные методы

    private void OnTouchDown(Finger finger)
    {
      _startPos = finger.currentTouch.screenPosition;
      _swiped = false;
    }
    
    private void OnTouchUp(Finger obj)
    {
      if (!_swiped)
        JumpForward?.Invoke();
    }

    private void OnTouchMove(Finger finger)
    {
      var screenPos = finger.currentTouch.screenPosition;
      var delta = Vector2.Distance(screenPos, _startPos);

      if (delta >= SwipeSensitivity)
      {
        var deltaX = Mathf.Abs(screenPos.x - _startPos.x);
        var deltaY = Mathf.Abs(screenPos.y - _startPos.y);

        if (deltaX >= deltaY)
        {
          if (_startPos.x > screenPos.x)
            MoveLeft?.Invoke();
          else
            MoveRight?.Invoke();
        }

        _swiped = true;
      }
    }

    #endregion
  }
}