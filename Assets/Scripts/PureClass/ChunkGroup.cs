using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkGroup 001", menuName = "DSI/ChunkGroup", order = 12)]
public class ChunkGroup : ScriptableObject{ 

    public List<TypeOfObstacle> typeOfObstacle;
    public List<float> timeBeforeNext;
    public List<float> speed;

    public int numberOfElement;

    public ChunkGroup(string Name)
    {
        name = Name;
    }

    public void AddOneElements ()
    {
        if(typeOfObstacle == null )
        {
            typeOfObstacle = new List<TypeOfObstacle>();
        }
        if (timeBeforeNext == null)
        {
            timeBeforeNext = new List<float>();
        }
        if (speed == null )
        {
            speed = new List<float>();
        }

        numberOfElement++;

        timeBeforeNext.Add(1.5f);
        typeOfObstacle.Add(TypeOfObstacle.Rectangle);
        speed.Add(7f);
    }

    public void RemoveOneElements()
    {
        numberOfElement--;
        if(numberOfElement<=0)
        {
            numberOfElement = 0;
        }
        typeOfObstacle.RemoveAt(typeOfObstacle.Count - 1);
        timeBeforeNext.RemoveAt(typeOfObstacle.Count - 1);
        speed.RemoveAt(typeOfObstacle.Count - 1);
    }

}
