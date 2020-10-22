using System;
using Application.UI;
using Common.Application;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Application.Management
{
  /// <inheritdoc/>
  public class UserDialogService : IUserDialogService
  {
    private RequestTextDialog _requestTextDialogPrefab;

    private object _lastDialogResult;
    
    public void RequestText(string message, Action<string> callback)
    {
      var canvas = Object.FindObjectOfType<Canvas>();
      var dialog = Object.Instantiate(_requestTextDialogPrefab, canvas.transform); // не тратим время на пул и фабрику
      dialog.Initialize(message, callback);
    }

    [Inject]
    private void Initialize(RequestTextDialog requestTextDialogPrefab)
    {
      _requestTextDialogPrefab = requestTextDialogPrefab;
    }
  }
}