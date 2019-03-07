using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsColorBeing : MonoBehaviour
{
    public Color colorOne;
    public Color colorTwo;

    public float colorSpeed = .1f;

    public void ChangeColorToOne(Material mat)
    {
        StartCoroutine(ChangeColor(mat, mat.GetColor("_Color"), colorOne));
    }
    public void ChangeColorToTwo(Material mat)
    {
        StartCoroutine(ChangeColor(mat, mat.GetColor("_Color"), colorTwo));
    }

    private IEnumerator ChangeColor(Material mat, Color colorA, Color colorB)
    {
        var colorDelta = 0.0f;
        while(colorDelta <1)
        {
            var color = Color.Lerp(colorA, colorB, colorDelta);
            mat.SetColor("_Color", color);
            colorDelta += colorSpeed;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
