using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBeing : MonoBehaviour
{
    public ColorState ColorState { get; set; }

    void Start()
    {
        Init();
    }

    private void Init()
    {
        SetColor(ColorState.ColorOne);
    }

    public void ChangeColor()
    {
        if (ColorState == ColorState.ColorOne)
        {
            SetColor(ColorState.ColorTwo);
        }
        else
        {
            SetColor(ColorState.ColorOne);
        }
    }


    private void SetColor(ColorState cs)
    {
        ColorState = cs;
        SetTag();
    }

    private void SetTag()
    {
        tag = ColorState.ToString();
    }
}
