using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChunkGroup { 

    public List<TypeOfObstacle> typeOfObstacle =  new List<TypeOfObstacle>();

    public string name = "CG001";

    public ChunkGroup(string Name)
    {
        name = Name;
    }
}
