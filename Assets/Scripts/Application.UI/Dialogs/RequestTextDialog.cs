using System;
using UnityEngine;
using UnityEngine.UI;

namespace Application.UI.Dialogs
{
  /// <summary>
  /// Диалоговое окно запроса текста.
  /// </summary>
  public class RequestTextDialog : MonoBehaviour
  {
    #region Поля

    [SerializeField]
    private Text _messageText = default;
    
    [SerializeField]
    private Button _applyBtn = default;
    
    [SerializeField]
    private InputField _input = default;

    private Action<string> _applyAction;

    #endregion

    #region Методы

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

    #endregion
  }
}