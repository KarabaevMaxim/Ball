using System;
using Common;
using Common.Props;
using ObjectsControlling.PlayerInput;
using UnityEngine;
using Zenject;

namespace ObjectsControlling
{
  /// <summary>
  /// Компонент ручного управления персонажем.
  /// </summary>
  public class PlayerController : MonoBehaviour, IController
  {
    #region Зависимости

    private IMovableObject _movableObject;
    private IJumpableObject _jumpableObject;
    private IGameplayProps _gameplayProps;
    private IInput _input;

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

    #region Остальные методы

    [Inject]
    private void Initialize(IMovableObject movableObject, IJumpableObject jumpableObject, IGameplayProps gameplayProps, IInput input)
    {
      _movableObject = movableObject;
      _jumpableObject = jumpableObject;
      _gameplayProps = gameplayProps;
      _input = input;
    }

    #endregion

    #region Обработчики событий

    private void OnMoveLeft()
    {
      if (!_jumpableObject.IsJumping && !_movableObject.IsMoving)
        if (_gameplayProps.MinLine < transform.position.x)
          _movableObject.StartMove(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
    }
    
    private void OnMoveRight()
    {
      if (!_jumpableObject.IsJumping && !_movableObject.IsMoving)
        if (_gameplayProps.MaxLine > transform.position.x)
          _movableObject.StartMove(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
    }
    
    private void OnJumpForward()
    {
      if (!_jumpableObject.IsJumping && !_movableObject.IsMoving)
        _jumpableObject.StartJump(transform.position.y + 1, transform.position.z + 1, TimeSpan.FromSeconds(1));
    }

    #endregion
  }
}