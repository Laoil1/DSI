using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputsManagers : MonoBehaviour
{

    public bool useSwipe;
    public float swipeDeadEnd = 15f;
    private Swipes currentSwipe;
    public UnityEvent rightSwapEvent;
    public UnityEvent leftsSwapEvent;
    private bool oneMove;


    public bool useTap;

    private bool hold;
    private bool release= true;




    // Start is called before the first frame update
    void Start()
    {
        currentSwipe = Swipes.Right;
    }

    private void Update()
    {
        if(useSwipe)
        {
            GetSwipe();
        }
        if(useTap)
        {
            GetTap();
        }
    }

    private void GetSwipe()
    {
        if(Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            oneMove = false;
            return;
        }

        if (oneMove)
        {
            return;
        }

        if (currentSwipe != Swipes.Right)
        {
            if (Input.GetTouch(0).deltaPosition.x > swipeDeadEnd)
            {
                currentSwipe = Swipes.Right;
                rightSwapEvent.Invoke();
                oneMove = true;
            }
        }

        if (currentSwipe != Swipes.Left)
        {
            if (Input.GetTouch(0).deltaPosition.x < -swipeDeadEnd)
            {
                currentSwipe = Swipes.Left;
                leftsSwapEvent.Invoke();
                oneMove = true;
            }
        }
    }

    private void GetTap()
    {
        if(Input.touchCount >0)
        {
            if(!hold)
            {
                hold = true;
                release = false;
                leftsSwapEvent.Invoke();
            }
        }
        else
        {
            if(!release)
            {
                release = true;
                hold = false;
                rightSwapEvent.Invoke();
            }

        }
    }
}
