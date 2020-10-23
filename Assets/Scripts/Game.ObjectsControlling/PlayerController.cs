using System;
using Common.Game.ObjectsModel;
using Common.Game.Props;
using Common.Game.Signals;
using Game.ObjectsControlling.PlayerInput;
using UnityEngine;
using Zenject;

namespace Game.ObjectsControlling
{
  /// <summary>
  /// Компонент ручного управления персонажем.
  /// </summary>
  public class PlayerController : MonoBehaviour, IController
  {
    private const float JumpTimeInSec = 0.5f;
    
    #region Зависимости

    private IMovableObject _movableObject;
    private IJumpableObject _jumpableObject;
    private IGameplayProps _gameplayProps;
    private IInput _input;
    private SignalBus _signalBus;

    #endregion

    #region IController

    public void StartBehaviour()
    {
      _input.Enabled = true;
      _input.JumpForward += OnJumpForward;
      _input.MoveLeft += OnMoveLeft;
      _input.MoveRight += OnMoveRight;
    }

    public void StopBehaviour()
    {
      _input.Enabled = false;
      _input.JumpForward -= OnJumpForward;
      _input.MoveLeft -= OnMoveLeft;
      _input.MoveRight -= OnMoveRight;
    }

    #endregion
    
    #region Обработчики событий

    private void OnMoveLeft()
    {
      if (!_jumpableObject.IsJumping && !_movableObject.IsMoving)
      {
        if (_gameplayProps.MinLane < transform.position.x)
        {
          var curPos = transform.position;
          _movableObject.StartMove(new Vector3(curPos.x - 1, curPos.y, curPos.z), null);
        }
      }
    }
    
    private void OnMoveRight()
    {
      if (!_jumpableObject.IsJumping && !_movableObject.IsMoving)
      {
        if (_gameplayProps.MaxLane > transform.position.x)
        {
          var curPos = transform.position;
          _movableObject.StartMove(new Vector3(curPos.x + 1, curPos.y, curPos.z), null);
        }
      }
    }
    
    private void OnJumpForward()
    {
      if (!_jumpableObject.IsJumping && !_movableObject.IsMoving)
      {
        var curPos = transform.position;
        _jumpableObject.StartJump(
          curPos.y + 1, curPos.z + 1, TimeSpan.FromSeconds(JumpTimeInSec), () => _signalBus.Fire<StairPassedSignal>());
      }
    }

    #endregion

    #region Остальные методы

    [Inject]
    private void Initialize(IMovableObject movableObject, IJumpableObject jumpableObject, IGameplayProps gameplayProps, IInput input, SignalBus signalBus)
    {
      _movableObject = movableObject;
      _jumpableObject = jumpableObject;
      _gameplayProps = gameplayProps;
      _input = input;
      _signalBus = signalBus;
    }

    #endregion
  }
}