using System;
using UnityEngine;
using UnityEngine.UI;

namespace Application.UI
{
  /// <summary>
  /// Диалоговое окно запроса текста.
  /// </summary>
  public class RequestTextDialog : MonoBehaviour
  {
    [SerializeField]
    private Text _messageText = default;
    
    [SerializeField]
    private Button _applyBtn = default;
    
    [SerializeField]
    private InputField _input = default;

    private Action<string> _applyAction;
    
    public void Initialize(string message, Action<string> callback)
    {
      _messageText.text = message;
      _applyAction = callback;
      _applyBtn.onClick.AddListener(OnApplyBtnClicked);
    }

    private void OnApplyBtnClicked()
    {
      _applyAction?.Invoke(_input.text);
      _applyBtn.onClick.RemoveAllListeners();
      Destroy(this);
    }
  }
}