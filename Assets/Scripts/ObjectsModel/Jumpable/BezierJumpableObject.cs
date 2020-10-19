using System;
using System.Collections;
using Infrastructure;
using UnityEngine;

namespace ObjectsModel.Jumpable
{
  public class BezierJumpableObject : JumpableObjectBase
  {
    private bool _isJumping;
    
    public override void StartJump(float targetY, TimeSpan time)
    {
      if(!_isJumping)
        StartCoroutine(Jumping(targetY, (float)time.TotalSeconds));
    }
    
    private IEnumerator Jumping(float targetY, float timeInSec)
    {
      var step = 0.0f;
      var thisTransform = gameObject.transform;
      var startPosition = transform.position;
      var heightForBezier = JumpHeight * 2;
      _isJumping = true;  
      
      while (step <= timeInSec)
      {
        step += Time.deltaTime;
        var deltaY = MathHelper.Bezier(startPosition.y, heightForBezier, targetY, step / timeInSec);
        thisTransform.position = new Vector3(transform.position.x, deltaY, thisTransform.position.z);
        yield return null;
      }
    
      thisTransform.position = new Vector3(thisTransform.position.x, targetY, thisTransform.position.z);
      _isJumping = false;
    }
  }
}