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

    public int NumberOfChunks = 3;

    public bool chunkRandom;

    public Color LevelColorOne;
    public Color LevelColorTwo;

    //public List<ChunkGroup> chunkGroup;

    public List<ChunkGroup> chunksGroup;


    public Level(int number, float tbo, float rtabo, Color colO, Color colT, float speed, int cc)
    {
        LevelNumber = number;
        TimeBetweenObstacle = tbo;
        RandomTimeAddBetweenObstacle = rtabo;
        LevelColorOne = colO;
        LevelColorTwo = colT;
        ObstacleSpeed = speed;
        MaxComboColor = cc;
        chunksGroup = new List<ChunkGroup>();

    }

    public Level(int number, float tbo, float rtabo, Color colO, Color colT, float speed, int cc, int noo, List<ChunkGroup> too)
    {
        LevelNumber = number;
        TimeBetweenObstacle = tbo;
        RandomTimeAddBetweenObstacle = rtabo;
        LevelColorOne = colO;
        LevelColorTwo = colT;
        ObstacleSpeed = speed;
        MaxComboColor = cc;
        NumberOfChunks = noo;
        chunksGroup = too;


    }

    public ChunkGroup GetChunkCount()
    {
        var _index = Random.Range(0, chunksGroup.Count);

        return chunksGroup[_index];
    }
}
