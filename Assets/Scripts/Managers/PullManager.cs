using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullManager : MonoBehaviour
{
    public InstantiateObstacle[] listEnemy;


    public InstantiateObstacle GetAvalaibleEnemy()
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


    public InstantiateObstacle GetAvalaibleEnemy(TypeOfObstacle typeOfEnnemy)
    {
        Debug.Log(typeOfEnnemy);
        foreach (var ene in listEnemy)
        {
            if (ene.availaible == true)
            {
                if (ene.typeOfEnemy == typeOfEnnemy)
                {
                    return ene;
                    Debug.Log(ene);

                }
            }
        }
        return null;
    }
}
