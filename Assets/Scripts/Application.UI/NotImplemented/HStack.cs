using System;
using System.Collections.Generic;
using UnityEngine;

namespace Application.UI.NotImplemented
{
  [ExecuteInEditMode]
  public class HStack : MonoBehaviour
  {
    [SerializeField]
    private float _spacing = default;
    
    [SerializeField]
    private Direction _direction = default;
    
    [SerializeField, HideInInspector]
    private List<StackChild> _children;
    
    [SerializeField, HideInInspector]
    private RectTransform _rectTransform;

    private void Update()
    {
      if (_direction == Direction.LeftToRight)
      {
        foreach (var child in _children)
        {
        }
      }
      else
      {
      }
    }

    private void OnValidate()
    {
      _children = new List<StackChild>(transform.childCount);
      
      for (var i = 0; i < transform.childCount; i++)
      {
        var child = transform.GetChild(i);

        if (child is RectTransform childTransform)
        {
          var element = childTransform.GetComponent<StackElement>();
          _children.Add(new StackChild(childTransform, element));
        }
      }
      
      _rectTransform = transform as RectTransform;
    }
    
    [Serializable]
    public struct StackChild
    {
      public RectTransform Transform { get; }
      
      public StackElement Element { get; }
      
      public StackChild(RectTransform transform, StackElement element)
      {
        Transform = transform;
        Element = element;
      }
    }

    public enum Direction
    {
      LeftToRight,
      RightToLeft
    }
  }
}