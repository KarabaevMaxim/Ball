using System;
using System.Collections;
using Common;
using ObjectsModel.Jumpable;
using ObjectsModel.Movable;
using UnityEngine;
using Zenject;

namespace ObjectsModel.Controlling
{
  public class PlayerController : MonoBehaviour, IController
  {
    private IMovableObject _movableObject;
    
    private IJumpableObject _jumpableObject;

    private IEnvironmentProps _environmentProps;
    
    private Coroutine _mainCoroutine;

    public void StartBehaviour()
    {
      _mainCoroutine = StartCoroutine(Behaviour());
    }

    public void StopBehaviour()
    {
      if (_mainCoroutine != null)
        StopCoroutine(_mainCoroutine);
    }

    private void Start()
    {
      StartBehaviour();
    }
    
    private IEnumerator Behaviour()
    {
      while (true)
      {
        if (!_jumpableObject.IsJumping && !_movableObject.IsMoving)
        {
          if (Input.GetKeyDown(KeyCode.Space))
          {
            _jumpableObject.StartJump(transform.position.y + 1, transform.position.z + 1, TimeSpan.FromSeconds(1));
            //_movableObject.StartMove(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1));
          }

          if (Input.GetKeyDown(KeyCode.A))
          {
            if (_environmentProps.MinLine < transform.position.x)
              _movableObject.StartMove(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
          }

          if (Input.GetKeyDown(KeyCode.D))
          {
            if (_environmentProps.MaxLine > transform.position.x)
              _movableObject.StartMove(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
          }
        }

        yield return null;
      }
    }

    [Inject]
    private void Initialize(IMovableObject movableObject, IJumpableObject jumpableObject, IEnvironmentProps environmentProps)
    {
      _movableObject = movableObject;
      _jumpableObject = jumpableObject;
      _environmentProps = environmentProps;
    }
  }
}