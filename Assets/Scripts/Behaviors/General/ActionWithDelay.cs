using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionWithDelay : MonoBehaviour
{
    public UnityEvent action;

    public void LaunchActionWithDelay(float delay)
    {
        StartCoroutine(StartDestroy(delay));
    }

    private IEnumerator StartDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
  
}
