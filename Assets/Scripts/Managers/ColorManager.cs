using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorManager : MonoBehaviour
{
    
    //Subscribe here the event thats affects gameplay
    [Header("Subscribe here the event thats affects gameplay")]
    public UnityEvent gameplayEventStateOne;

    //Subscribe here the event thats affects graphics
    [Header("Subscribe here the event thats affects graphics")]
    public UnityEvent graphicsEventsStateOne;

    [Header("Subscribe here the event thats affects gameplay")]
    public UnityEvent gameplayEventStateTwo;

    //Subscribe here the event thats affects graphics
    [Header("Subscribe here the event thats affects graphics")]
    public UnityEvent graphicsEventsStateTwo;

    public void LaunchesEventOnes()
    {
        gameplayEventStateOne.Invoke();
        graphicsEventsStateOne.Invoke();
    }

    public void LaunchesEventTwo()
    {
        gameplayEventStateTwo.Invoke();
        graphicsEventsStateTwo.Invoke();
    }
}
