using Common.Application;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
  public class BestResultControl : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private Text _text;

    private void OnValidate()
    {
      if (!_text)
        _text = GetComponent<Text>();
    }

    [Inject]
    private void Initialize(ICurrentUserInfoService currentUserInfoService)
    {
      _text.text = $"Рекорд: {currentUserInfoService.CurrentUser.BestResult.ToString()}";
    }
  }
}