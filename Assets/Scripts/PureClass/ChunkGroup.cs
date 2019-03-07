using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkGroup 001", menuName = "DSI/ChunkGroup", order = 12)]
public class ChunkGroup : ScriptableObject{ 

    public List<TypeOfObstacle> typeOfObstacle =  new List<TypeOfObstacle>();
    public List<float> timeBeforeNext = new List<float>();
    public List<float> speed = new List<float>();

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
        timeBeforeNext.Add(1.5f);
        typeOfObstacle.Add(TypeOfObstacle.Rectangle);
        speed.Add(7f);
    }

    public void RemoveOneElements()
    {
        typeOfObstacle.RemoveAt(typeOfObstacle.Count - 1);
        timeBeforeNext.RemoveAt(typeOfObstacle.Count - 1);
        speed.RemoveAt(typeOfObstacle.Count - 1);
    }

}
