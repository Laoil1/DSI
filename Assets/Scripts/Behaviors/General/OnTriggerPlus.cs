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
    public bool UseAnotherTag;
    public string EnteredTag;

    public bool is2D;
    public UnityEvent consequences;
    public UnityEvent consequencesAnotherTag;
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
                if (other.tag == tag)
                {
                    consequences.Invoke();
                }
            }
            
            if(UseAnotherTag)
            {
                if(other.tag == EnteredTag)
                {
                    consequencesAnotherTag.Invoke();
                }
            }
            if (other.tag != EnteredTag && other.tag != tag)
            {
                elseTagConsequences.Invoke();
                return;
            }
        }
        else
        {
            consequences.Invoke();
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
        consequences.Invoke();
    }
}

