using Common.Application;
using UnityEngine.SceneManagement;

namespace Application.Management
{
  public class Mediator : IMediator // todo придумать более подходящее имя
  {
    private readonly ICurrentUserInfoService _currentUserInfoService;

    private readonly IUserDialogService _userDialogService;

    public void StartGame()
    {
      _userDialogService.RequestText("Введите имя", async name =>
      {
        await _currentUserInfoService.RegisterAsync(name);
        LoadScene(Scene.Game);
      });
    }

    public void RestartGame()
    {
      LoadScene(Scene.Game);
    }

    private void LoadScene(Scene scene)
    {
      SceneManager.LoadScene(scene.ToString());
    }

    public Mediator(ICurrentUserInfoService currentUserInfoService, IUserDialogService userDialogService)
    {
      _currentUserInfoService = currentUserInfoService;
      _userDialogService = userDialogService;
    }
    
    private enum Scene
    {
      Game,
      Menu
    }
  }
}