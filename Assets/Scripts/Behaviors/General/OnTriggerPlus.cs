using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class OnTriggerPlus : MonoBehaviour
{

    // Ask simon tomorrow
    public bool IsTag;
    public bool UseSameTag;
    public string EnteredTag;
    public string EnteredTagTwo;

    public bool is2D;
    public UnityEvent consequencesSameTag;
    public UnityEvent consequencesTag;
    public UnityEvent elseTagConsequences;


    private void OnTriggerEnter(Collider other)
    {
        if (is2D)
        {
            return;
        }
        if(IsTag)
        {
            if (UseSameTag)
            {
                if (other.tag != tag || other.tag !=EnteredTag)
                {
                    elseTagConsequences.Invoke();
                    return;
                }
                consequencesSameTag.Invoke();
            }
            if(IsTag)
            {
                if(other.tag != EnteredTag)
                {
                    consequencesTag.Invoke();
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!is2D)
        {
            return;
        }
        if (IsTag)
        {
            if (UseSameTag)
            {
                if (other.tag != tag)
                {
                    elseTagConsequences.Invoke();
                    return;
                }
            }
            else
            {
                if (other.tag != EnteredTag)
                {
                    return;
                }
            }
        }
        consequencesSameTag.Invoke();
    }
}

