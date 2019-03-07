using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DothingsOutsideOfScreen : MonoBehaviour
{

    public float DownBound =-5f;
    public bool checkDown = true;
    public float UpBound = 5f;
    public bool checkUp = true;

    public float LeftBound =-5f;
    public bool checkLeft = true;

    public float RightBound=5f;
    public bool checkRight = true;

    private Transform self; 

    public UnityEvent consequences;
    
    private void Awake()
    {
        self = transform;
    }

    private void Start()
    {
        if(checkDown)
            StartCoroutine(TestBoundDown());
            
        if(checkUp)
            StartCoroutine(TestBoundUp());
            
        if(checkLeft)
            StartCoroutine(TestBoundLeft());
            
        if(checkRight)
            StartCoroutine(TestBoundRight());
    }

    private IEnumerator TestBoundDown()
    {
        yield return new WaitUntil(()=>self.position.y<DownBound);
        
        consequences.Invoke();

        yield break;
    }
    private IEnumerator TestBoundUp()
    {
        yield return new WaitUntil(()=>self.position.y>UpBound);
        
        consequences.Invoke();

        yield break;
    }
    private IEnumerator TestBoundLeft()
    {
        yield return new WaitUntil(()=>self.position.x<LeftBound);
        
        consequences.Invoke();

        yield break;
    }

    private IEnumerator TestBoundRight()
    {
        yield return new WaitUntil(()=>self.position.x>RightBound);
        
        consequences.Invoke();

        yield break;
    }

}
