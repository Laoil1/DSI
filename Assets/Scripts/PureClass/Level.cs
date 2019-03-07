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

    /*
    public int LevelNumber { get; set; }

    public float TimeBetweenObstacle { get; set; }
    public float RandomTimeAddBetweenObstacle { get; set; }

    public float ObstacleSpeed { get; set; }

    public int MaxComboColor { get; set; }

    public Color LevelColorOne { get; set; }
    public Color LevelColorTwo { get; set; }
    */

    public Level(int number, float tbo, float rtabo, Color colO, Color colT, float speed, int cc)
    {
        LevelNumber = number;
        TimeBetweenObstacle = tbo;
        RandomTimeAddBetweenObstacle = rtabo;
        LevelColorOne = colO;
        LevelColorTwo = colT;
        ObstacleSpeed = speed;
        MaxComboColor = cc;

    }


    public Level(int number, float tbo, float rtabo, Color colO, Color colT, float speed, int cc, int noo)
    {
        LevelNumber = number;
        TimeBetweenObstacle = tbo;
        RandomTimeAddBetweenObstacle = rtabo;
        LevelColorOne = colO;
        LevelColorTwo = colT;
        ObstacleSpeed = speed;
        MaxComboColor = cc;
        NumberOfObstacle = noo;

    }

}
