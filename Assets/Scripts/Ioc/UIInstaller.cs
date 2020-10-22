using Application.UI;
using Application.UI.Dialogs;
using UnityEngine;
using Zenject;

namespace Ioc
{
  [CreateAssetMenu(fileName = "UIInstaller", menuName = "Application/UI")]
  public class UIInstaller : ScriptableObjectInstaller<UIInstaller>
  {
    [SerializeField]
    private RequestTextDialog _requestTextDialog = default;
    
    public override void InstallBindings()
    {
      Container.Bind<RequestTextDialog>().FromInstance(_requestTextDialog).IfNotBound();
    }
  }
}