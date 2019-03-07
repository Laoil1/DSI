using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChanger : MonoBehaviour
{

    public Color c1;
    public Color c2;

    public void ChangeBGcol(Camera cam)
    {
        if(cam.backgroundColor == c1)
        {
            cam.backgroundColor = c2;
        }
        else
        {
            cam.backgroundColor = c1;
        }
    }

}
