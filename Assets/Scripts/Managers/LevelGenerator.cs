using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "lg", menuName = "levelGenerator", order = 17)]
public class LevelGenerator : ScriptableObject
{

    //[HideInInspector]
    public List<Level> listOfLevels;

    [HideInInspector]
    public int levelDivide;

    [HideInInspector]
    public int tempLevelDivide;

    [HideInInspector]
    public int numberOfLevel;

    [HideInInspector]
    public Level currentLevelGroup;

    //[HideInInspector]

    public List<Level> levelGroups;

    public void GenerateLevelsBase()
    {
        listOfLevels = new List<Level>();
        listOfLevels.Add(new Level(0, 1.5f, 0.5f, Color.white, Color.black, 7f, 3));
    }

    public void AddLevels(int number)
    {
        for (int i = 0; i < number; i++)
        {
            listOfLevels.Add(new Level(0, 1.5f, 0.5f, Color.white, Color.black, 7f, 3));
        }
    }

    public void RemoveLevels(int number)
    {
        var tempCount = listOfLevels.Count-1;
        if(tempCount-number<0)
        {
            for (int i = tempCount; i > 0; i--)
            {
                listOfLevels.RemoveAt(i);
            }
            return;
        }

        for (int i = tempCount; i > tempCount-number; i--)
        {
            listOfLevels.RemoveAt(i);
        }
    }

    public void SetDivide(int divideN)
    {
        levelDivide = divideN;

        var _numberGroup = listOfLevels.Count / levelDivide + 1; //c'est le 0 ça


        if(listOfLevels.Count % levelDivide != 0)
        {
            if(listOfLevels.Count-1 != (_numberGroup-1)*levelDivide)
            {
                _numberGroup++;
            }
        }

        if (levelGroups == null)
        {
            levelGroups = new List<Level>();
        }
        

        if(levelGroups.Count>_numberGroup)
        {
            for (int i = levelGroups.Count-1; i >= _numberGroup; i--)
            {
                levelGroups.RemoveAt(i);
            }
        }

        if (levelGroups.Count < _numberGroup)
        {
            for (int i = levelGroups.Count; i < _numberGroup; i++)
            {
                levelGroups.Add(new Level(0, 1.5f, 0.5f, Color.white, Color.black, 7f, 3));
            }
        }

    }

    public void GenerateLevel()
    {
        for (int i = 0; i < levelGroups.Count-1; i++)
        {
            AddWithEvolution(levelGroups[i], levelGroups[i + 1]);
        }
        AddOneLevel(levelGroups[levelGroups.Count - 1]);
    }

    public void AddWithEvolution(Level levelone, Level levelTwo)
    {
        for (int i = levelone.LevelNumber; i < levelTwo.LevelNumber; i++)
        {
            float _index = i - levelone.LevelNumber;
            float _ratioMax = levelTwo.LevelNumber - levelone.LevelNumber;

            float _ratio = _index/ _ratioMax;

            float _TimeBetweenObstacle = Mathf.Lerp( levelone.TimeBetweenObstacle, levelTwo.TimeBetweenObstacle, _ratio);
            float _RandomTimeAddBetweenObstacle = Mathf.Lerp(levelone.RandomTimeAddBetweenObstacle, levelTwo.RandomTimeAddBetweenObstacle, _ratio);

            float _ObstacleSpeed = Mathf.Lerp(levelone.ObstacleSpeed, levelTwo.ObstacleSpeed, _ratio);

            int _MaxComboColor =  Mathf.FloorToInt( levelone.MaxComboColor + levelTwo.MaxComboColor * _ratio);

            int _NumberOfObstacle = Mathf.FloorToInt(levelone.NumberOfObstacle + levelTwo.NumberOfObstacle * _ratio);

            Color _LevelColorOne = Color.Lerp (levelone.LevelColorOne, levelTwo.LevelColorOne,  _ratio);
            Color _LevelColorTwo = Color.Lerp(levelone.LevelColorTwo, levelTwo.LevelColorTwo, _ratio);

            List<TypeOfObstacle> _ChunkGroup = levelone.chunkGroup;

            listOfLevels[i] = new Level(i, _TimeBetweenObstacle, _RandomTimeAddBetweenObstacle, _LevelColorOne, _LevelColorTwo, _ObstacleSpeed, _MaxComboColor, _NumberOfObstacle, _ChunkGroup);
        }
    }

    public void AddOneLevel(Level level)
    {
        listOfLevels[listOfLevels.Count - 1] = level;
    }
}
