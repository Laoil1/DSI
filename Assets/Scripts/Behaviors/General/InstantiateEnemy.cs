using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{

    public bool availaible = true;

    public Transform self;
    public ContinuousMovement cm;

    public MeshRenderer mr;

    public Collider col;


    public Material matOne;
    public Material matTwo;

    private ColorState cs;

    public ColorState Instantiate(Vector3 pos, float speed)
    {

        col.enabled = true;
        mr.enabled = true;

        cs = (ColorState) Random.Range(0, 2);
        SetColor();
        self.position = pos;
        cm.speed = speed;
        cm.LaunchMove();

        availaible = false;

        return cs;
    }

    public ColorState Instantiate(Vector3 pos, float speed, ColorState colorState)
    {
        gameObject.SetActive(true);
        cs = colorState;
        SetColor();
        self.position = pos;
        cm.speed = speed;
        cm.LaunchMove();

        availaible = false;

        return cs;
    }

    private void SetColor()
    {
        switch (cs)
        {
            case ColorState.ColorOne:
                tag = "ColorOne";
                mr.material = matOne;
                break;

            case ColorState.ColorTwo:
                tag = "ColorTwo";
                mr.material = matTwo;
                break;

            default:
                break;
        }
    }

    public void Die()
    {
        availaible = true;

        self.position = new Vector3(100f,100f,100f);
        cm.Stop();

        mr.enabled = false;
        cm.enabled = false;


    }

}
