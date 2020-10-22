using Application.UI.Dialogs;
using UnityEngine;
using Zenject;

namespace Ioc
{
  [CreateAssetMenu(fileName = "UIInstaller", menuName = "Application/UI")]
  public class UIInstaller : ScriptableObjectInstaller<UIInstaller>
  {
    [SerializeField]
    private RequestTextDialog _requestTextDialogPrefab = default;
    
    [SerializeField]
    private SimpleDialog _simpleDialogPrefab = default;
    
    public override void InstallBindings()
    {
      Container.Bind<RequestTextDialog>().FromInstance(_requestTextDialogPrefab).IfNotBound();
      Container.Bind<SimpleDialog>().FromInstance(_simpleDialogPrefab).IfNotBound();
    }
  }
}