using Cinemachine;
using Common.Game.ObjectsModel;
using Common.Game.Props;
using Common.Game.Spawners;
using UnityEngine;
using Zenject;

namespace Game.Management
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
    private readonly CinemachineVirtualCamera _virtualCamera;

    #endregion

    #region Поля

    private ICharacter _character;

    #endregion
    
    public ICharacter Spawn(Vector3 position)
    {
      var obj = _factory.Create(_characterPrefab as Object);
      obj.Position = position;
      obj.OnSpawned();
      _virtualCamera.Follow = obj.Transform;
      _virtualCamera.LookAt = obj.Transform;
      _character = obj;
      return obj;
    }

    public ICharacter SpawnOnStart()
    {
      return Spawn(_gameplayProps.PlayerStartPosition);
    }

    public void Despawn()
    {
      _character.OnDespawned();
      Object.Destroy(_character as Object);
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