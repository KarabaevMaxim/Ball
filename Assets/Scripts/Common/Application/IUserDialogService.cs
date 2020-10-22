using System;

namespace Common.Application
{
  /// <summary>
  /// Сервис диалоговых окон.
  /// </summary>
  public interface IUserDialogService
  {
    void RequestText(string message, Action<string> callback);

    void ShowDialog(string message);
  }
}