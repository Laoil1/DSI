using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDeletePlus : MonoBehaviour
{
    public UnityEvent cons;

    private void OnDestroy()
    {
        cons.Invoke();
    }

}
