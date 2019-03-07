using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatColorWithGradient : MonoBehaviour
{
    public Gradient gradient;
    public MeshRenderer mr;
    public float speed=0.5f;
    private float time;

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime * speed;
        if(time>=1)
        {
            time = 0;
        }

        mr.material.SetColor("_Color", gradient.Evaluate(time));
    }
}
