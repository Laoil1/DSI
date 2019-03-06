using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Miscellaneous : MonoBehaviour
{
    //Destroy the targeted object
    public void DestroyAnObject(Object obj)
    {
        Destroy(obj);
    }

    public void Disable(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Enable(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    
}
