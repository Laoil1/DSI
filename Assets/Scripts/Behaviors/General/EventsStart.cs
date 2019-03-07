using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsStart : MonoBehaviour
{
    public UnityEvent startEvents;
    // Start is called before the first frame update
    public void Start()
    {
        startEvents.Invoke();
    }
    
}
