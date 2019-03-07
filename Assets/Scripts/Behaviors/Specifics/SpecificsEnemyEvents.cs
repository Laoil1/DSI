using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificsEnemyEvents : MonoBehaviour
{

    public void ChangeMatToOposite(InstantiateObstacle ie)
    {
        Material mat = ie.matOne;
        tag = "ColorOne";
        if(ie.cs == ColorState.ColorOne)
        {
            mat = ie.matTwo;
            tag = "ColorTwo";
        }
        GetComponent<MeshRenderer>().material = mat;
    }

    public void ChangeMatToSame(InstantiateObstacle ie)
    {
        Material mat = ie.matOne;
        tag = "ColorOne";
        if (ie.cs == ColorState.ColorTwo)
        {
            mat = ie.matTwo;
            tag = "ColorTwo";
        }
        GetComponent<MeshRenderer>().material = mat;
    }

    public void LaunchRotate(float speed)
    {
        StartCoroutine(Rotate(speed));
    }

    private IEnumerator Rotate(float speed)
    {
        yield return new WaitForSeconds(Time.deltaTime);

        transform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);
        StartCoroutine(Rotate(speed));
    }

    public void DecalRandom(float dec)
    {
        var _mult = Random.Range(0, 2);
        if(_mult == 0)
        {
            _mult = -1;
        }
        transform.position += _mult * new Vector3 (dec,0f,0f);
    }

    public void DesactivateMesh(MeshRenderer mr)
    {
        mr.enabled = false;
    }

    public void ActivateMesh(MeshRenderer mr)
    {
        mr.enabled = true;
    }


    public void DesactivateCollider(Collider mr)
    {
        mr.enabled = false;
    }

    public void ActivateCollider(Collider mr)
    {
        mr.enabled = true;
    }
}
