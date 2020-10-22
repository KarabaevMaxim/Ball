using Application.UI;
using UnityEngine;
using Zenject;

namespace Ioc
{
  [CreateAssetMenu(fileName = "UIInstaller", menuName = "Appliaction/UI")]
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