using Cinemachine;
using Common;
using Common.Props;
using UnityEngine;
using Zenject;

namespace GameManagement
{
  /// <summary>
  /// Спавнер игровых персонажей.
  /// </summary>
  public class CharactersSpawner : ICharactersSpawner
  {
    #region Зависимости

    private readonly Factory _factory;
    private readonly ICharacter _characterPrefab;
    private readonly IGameplayProps _gameplayProps;
    private CinemachineVirtualCamera _virtualCamera;

    #endregion

    public ICharacter Spawn(Vector3 position)
    {
      var obj = _factory.Create(_characterPrefab as Object);
      obj.Position = position;
      obj.OnSpawned();
      _virtualCamera.Follow = obj.Transform;
      _virtualCamera.LookAt = obj.Transform;
      return obj;
    }

    public ICharacter SpawnOnStart()
    {
      return Spawn(_gameplayProps.PlayerStartPosition);
    }
    
    public CharactersSpawner(Factory factory, ICharacter characterPrefab, IGameplayProps gameplayProps, CinemachineVirtualCamera virtualCamera)
    {
      _factory = factory;
      _characterPrefab = characterPrefab;
      _gameplayProps = gameplayProps;
      _virtualCamera = virtualCamera;
    }

    #region Вложенные типы

    public class Factory : PlaceholderFactory<Object, ICharacter>
    {
    }

    #endregion
  }
}