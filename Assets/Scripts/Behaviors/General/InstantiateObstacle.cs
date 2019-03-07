using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypeOfObstacle
{
    Rectangle,
    Circle,
    FortyFiveRect,
    MinusFortyFiveRect,
    //BlockBar,
    LongBlocs,
    Cross,
    /*Hexa,
    MovingHexa,
    Donut,
    FortyFiveBlocsFall,
    Star,
    Door,
    Canon,
    Spike,
    Snake*/
    ChangeLevel,
}

public class InstantiateObstacle : MonoBehaviour
{

    public bool availaible = true;

    public Transform self;
    public ContinuousMovement cm;

    public MeshRenderer mr;

    public Collider col;


    public Material matOne;
    public Material matTwo;

    public ColorState cs;

    public TypeOfObstacle typeOfEnemy;

    public UnityEvent OnInstantiate;
    public UnityEvent OnDie;

    public ColorState Instantiate(Vector3 pos, float speed)
    {
        if(col!=null)
            col.enabled = true;
        if (mr != null)
            mr.enabled = true;

        cs = (ColorState) Random.Range(0, 2);
        SetColor();
        self.position = pos;
        cm.speed = speed;
        cm.LaunchMove();

        availaible = false;

        OnInstantiate.Invoke();

        return cs;
    }

    public ColorState Instantiate(Vector3 pos, float speed, ColorState colorState)
    {
        if (col != null)
            col.enabled = true;
        if (mr != null)
            mr.enabled = true;
        cs = colorState;

        if(typeOfEnemy != TypeOfObstacle.ChangeLevel)
            SetColor();

        self.position = pos;
        cm.speed = speed;
        cm.LaunchMove();

        availaible = false;

        OnInstantiate.Invoke();

        return cs;
    }

    private void SetColor()
    {
        switch (cs)
        {
            case ColorState.ColorOne:
                tag = "ColorOne";
                if (mr != null)
                    mr.material = matOne;
                break;

            case ColorState.ColorTwo:
                tag = "ColorTwo";
                if (mr != null)
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

        if (mr != null)
            mr.enabled = false;

        if (col != null)
            cm.enabled = false;

        OnDie.Invoke();
    }

}
