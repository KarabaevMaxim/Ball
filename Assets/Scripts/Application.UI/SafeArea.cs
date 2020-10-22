using UnityEngine;

namespace Application.UI
{
  /// <summary>
  /// Safe area implementation for notched mobile devices. Usage:
  ///  (1) Add this component to the top level of any GUI panel. 
  ///  (2) If the panel uses a full screen background image, then create an immediate child and put the component on that instead, with all other elements childed below it.
  ///      This will allow the background image to stretch to the full extents of the screen behind the notch, which looks nicer.
  ///  (3) For other cases that use a mixture of full horizontal and vertical background stripes, use the Conform X & Y controls on separate elements as needed.
  /// </summary>
  [ExecuteInEditMode]
  public class SafeArea : MonoBehaviour
  {
    #region Поля

    /// <summary>
    /// Адаптировать UI по оси X?
    /// </summary>
    [SerializeField]
    private bool _conformX = true;

    /// <summary>
    /// Адаптировать UI по оси Y?
    /// </summary>
    [SerializeField]
    private bool _conformY = true;

    /// <summary>
    /// Ссылка на Rect объекта.
    /// </summary>
    private RectTransform _panel;

    private Vector2 _lastScreenSize = Vector2.zero;

    #endregion

    #region Методы жизненного цикла

    /// <summary>
    /// Выполняет преинициализацию объекта.
    /// </summary>
    private void Awake()
    {
      _panel = GetComponent<RectTransform>();

      if (_panel == null)
      {
        Debug.LogError($"Cannot apply safe area - no RectTransform found on {name}");
        Destroy(gameObject);
      }

      _lastScreenSize = new Vector2(Screen.width, Screen.height);
      ApplySafeArea();
    }

    /// <summary>
    /// Выполняет обработку кадра.
    /// </summary>
    private void Update()
    {
      if (Screen.width != _lastScreenSize.x || Screen.height != _lastScreenSize.y)
      {
        _lastScreenSize = new Vector2(Screen.width, Screen.height);
        ApplySafeArea();
      }
    }

    private void OnEnable()
    {
      _lastScreenSize = new Vector2(Screen.width, Screen.height);
      ApplySafeArea();
    }

    #endregion

    #region Остальные методы

    /// <summary>
    /// Адаптирует верстку под safeArea.
    /// </summary>
    private void ApplySafeArea()
    {
      var safeArea = Screen.safeArea;

      if (!_conformX)
      {
        safeArea.x = 0;
        safeArea.width = Screen.width;
      }

      if (!_conformY)
      {
        safeArea.y = 0;
        safeArea.height = Screen.height;
      }

      var anchorMin = safeArea.position;
      var anchorMax = safeArea.position + safeArea.size;
      anchorMin.x /= Screen.width;
      anchorMin.y /= Screen.height;
      anchorMax.x /= Screen.width;
      anchorMax.y /= Screen.height;
      _panel.anchorMin = anchorMin;
      _panel.anchorMax = anchorMax;
    }

    #endregion
  }
}