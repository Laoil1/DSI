using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level 
{

    public int LevelNumber;

    public float TimeBetweenObstacle;
    public float RandomTimeAddBetweenObstacle;

    public float ObstacleSpeed;

    public int MaxComboColor;

    public int NumberOfObstacle = 3;

    public Color LevelColorOne;
    public Color LevelColorTwo;

    //public List<ChunkGroup> chunkGroup;
    public List<TypeOfObstacle> chunkGroup;

    public Level(int number, float tbo, float rtabo, Color colO, Color colT, float speed, int cc)
    {
        LevelNumber = number;
        TimeBetweenObstacle = tbo;
        RandomTimeAddBetweenObstacle = rtabo;
        LevelColorOne = colO;
        LevelColorTwo = colT;
        ObstacleSpeed = speed;
        MaxComboColor = cc;
        chunkGroup = new List<TypeOfObstacle>();

    }

    public Level(int number, float tbo, float rtabo, Color colO, Color colT, float speed, int cc, int noo, List<TypeOfObstacle> too)
    {
        LevelNumber = number;
        TimeBetweenObstacle = tbo;
        RandomTimeAddBetweenObstacle = rtabo;
        LevelColorOne = colO;
        LevelColorTwo = colT;
        ObstacleSpeed = speed;
        MaxComboColor = cc;
        NumberOfObstacle = noo;
        chunkGroup = too;


    }

    public TypeOfObstacle GetObstacle()
    {
        var _index = Random.Range(0, chunkGroup.Count);

        return chunkGroup[_index];
    }
}
