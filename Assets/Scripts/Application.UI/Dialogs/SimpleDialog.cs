using System;
using UnityEngine;
using UnityEngine.UI;

namespace Application.UI.Dialogs
{
  public class SimpleDialog : MonoBehaviour
  {
    #region Поля

    [SerializeField]
    private Text _messageText = default;
    
    [SerializeField]
    private Button _applyBtn = default;

    private Action _applyAction;

    #endregion

    #region Методы

    public void Initialize(string message, Action callback)
    {
      _messageText.text = message;
      _applyAction = callback;
      _applyBtn.onClick.AddListener(OnApplyBtnClicked);
    }

    private void OnApplyBtnClicked()
    {
      _applyAction?.Invoke();
      _applyBtn.onClick.RemoveAllListeners();
      Destroy(gameObject);
    }

    #endregion
  }
}