using System;
using UnityEngine;

namespace Application.UI.NotImplemented
{
  [Obsolete(nameof(HStack) + " не реализован")]
  public class StackElement : MonoBehaviour
  {
    [SerializeField, Range(0, 1)]
    private float _weight = default;

    public float Weight => _weight;
  }
}