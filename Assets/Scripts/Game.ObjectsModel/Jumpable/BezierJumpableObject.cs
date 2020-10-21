using System;
using System.Collections;
using Infrastructure;
using UnityEngine;

namespace Game.ObjectsModel.Jumpable
{
  public class BezierJumpableObject : JumpableObjectBase
  {
    public override void StartJump(float targetY, TimeSpan time)
    {
      if (!IsJumping)
      {
        StartCoroutine(Jumping(targetY, (float)time.TotalSeconds));
        IsJumping = true;
      }
    }
    
    public override void StartJump(float targetY, float targetZ, TimeSpan time, Action callback)
    {
      if (!IsJumping)
      {
        StartCoroutine(Jumping(targetY, targetZ, time, callback));
        IsJumping = true;
      }
    }
    
    private IEnumerator Jumping(float targetY, float timeInSec)
    {
      var step = 0.0f;
      var startY = transform.position.y;
      var middleY = transform.position.y + JumpHeight * 2;

      while (step <= timeInSec)
      {
        step += Time.deltaTime;
        var newY = MathHelper.Bezier(startY, middleY, targetY, step / timeInSec);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        yield return null;
      }
    
      transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
      IsJumping = false;
    }
    
    private IEnumerator Jumping(float targetY, float targetZ, TimeSpan jumpTime, Action callback)
    {
      var step = 0.0f;
      var startPosition = transform.position;
      var middleY = transform.position.y + JumpHeight * 2;

      while (step <= jumpTime.TotalSeconds)
      {
        step += Time.deltaTime;
        var calculatedStep = step / (float) jumpTime.TotalSeconds;
        var newY = MathHelper.Bezier(startPosition.y, middleY, targetY, calculatedStep);
        var newZ = Mathf.Lerp(startPosition.z, targetZ, calculatedStep);
        transform.position = new Vector3(transform.position.x, newY, newZ);
        yield return null;
      }

      transform.position = new Vector3(transform.position.x, targetY, targetZ);
      IsJumping = false;
      callback?.Invoke();
    }
  }
}