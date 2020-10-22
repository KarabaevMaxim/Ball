using System;
using Application.UI.Dialogs;
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
    private SimpleDialog _simpleDialogPrefab;

    public void RequestText(string message, Action<string> callback)
    {
      var canvas = Object.FindObjectOfType<Canvas>();
      var dialog = Object.Instantiate(_requestTextDialogPrefab, canvas.transform); // не тратим время на пул и фабрику
      dialog.Initialize(message, callback);
    }

    public void ShowDialog(string message)
    {
      var canvas = Object.FindObjectOfType<Canvas>();
      var dialog = Object.Instantiate(_simpleDialogPrefab, canvas.transform);
      dialog.Initialize(message, null);
    }

    [Inject]
    private void Initialize(RequestTextDialog requestTextDialogPrefab, SimpleDialog simpleDialogPrefab)
    {
      _requestTextDialogPrefab = requestTextDialogPrefab;
      _simpleDialogPrefab = simpleDialogPrefab;
    }
  }
}