using Common.Application;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
  public class MenuBtn : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private Button _button;
    
    private void OnValidate()
    {
      if (!_button)
        _button = GetComponent<Button>();
    }

    private void OnDestroy()
    {
      _button.onClick.RemoveAllListeners();
    }

    [Inject]
    private void Initialize(IMediator mediator)
    {
      _button.onClick.AddListener(mediator.OpenMenu);
    }
  }
}