using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 1f;
    public Transform self;

    public Vector3 direction;

    private bool isStoped;
    private Coroutine contiMove;

    public void LaunchMove()
    {
        contiMove = StartCoroutine(ContinuousMove());
    }

    private IEnumerator ContinuousMove ()
    {
        yield return new WaitForSeconds(Time.deltaTime);

        self.position += direction * speed * Time.deltaTime;

        contiMove = StartCoroutine (ContinuousMove());
    }

    public void Stop()
    {
        StopCoroutine(contiMove);
    }


}
