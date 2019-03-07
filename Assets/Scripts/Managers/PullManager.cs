using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullManager : MonoBehaviour
{
    public InstantiateEnemy[] listEnemy;


    public InstantiateEnemy GetAvalaibleEnemy()
    {
        foreach (var ene in listEnemy)
        {
            if(ene.availaible == true)
            {
                return ene;
            }
        }

        return null;
    }
   
}
