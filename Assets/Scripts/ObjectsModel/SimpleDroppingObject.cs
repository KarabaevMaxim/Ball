using System.Collections;
using Common.ObjectsModel;
using UnityEngine;

namespace ObjectsModel
{
  /// <summary>
  /// Компонент объекта, который может падать.
  /// </summary>
  public class SimpleDroppingObject : MonoBehaviour, IDroppingObject
  {
    #region Поля настроек

    [SerializeField]
    private float _droppingSpeed = default;

    #endregion

    #region Поля

    private readonly RaycastHit[] _buffer = new RaycastHit[1];

    #endregion

    #region ISimpleDroppingObject

    public bool IsDropping { get; private set; }

    public void StartDrop()
    {
      StartCoroutine(Dropping());
    }

    #endregion

    #region Остальные методы

    private IEnumerator Dropping()
    {
      IsDropping = true;

      while (true)
      {
        if (Physics.RaycastNonAlloc(transform.position, Vector3.down, _buffer, 0.0000001f) == 1)
        {
          transform.position = new Vector3(transform.position.x, Mathf.Round(transform.position.y), transform.position.z);
          break;
        }

        var delta = _droppingSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y - delta, transform.position.z);
        yield return null;
      }

      IsDropping = false;
    }
    
    #endregion
  }
}