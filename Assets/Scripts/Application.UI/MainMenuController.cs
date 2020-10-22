using System;
using Common.Application;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Application.UI
{
  public class MainMenuController : MonoBehaviour
  {
    [SerializeField]
    private Button _playBtn = default;

    private IMediator _mediator;

    private void Awake()
    {
      _playBtn.onClick.AddListener(() => _mediator.StartGame());
    }

    private void OnDestroy()
    {
      _playBtn.onClick.RemoveAllListeners();
    }

    [Inject]
    private void Initialize(IMediator mediator)
    {
      _mediator = mediator;
    }
  }
}