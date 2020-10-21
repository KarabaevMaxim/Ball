using System;
using Common.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
  public class ProgressTextControl : MonoBehaviour
  {
    private SignalBus _signalBus;
    
    [SerializeField, HideInInspector]
    private Text _text;

    private void OnProgressChanged(ProgressChangedSignal signal)
    {
      _text.text = signal.Value.ToString();
    }
    
    private void OnValidate()
    {
      if (!_text)
        _text = GetComponent<Text>();
    }

    private void OnDestroy()
    {
      _signalBus.Unsubscribe<ProgressChangedSignal>(OnProgressChanged);
    }

    [Inject]
    private void Initialize(SignalBus signalBus)
    {
      _signalBus = signalBus;
      _signalBus.Subscribe<ProgressChangedSignal>(OnProgressChanged);
    }
  }
}